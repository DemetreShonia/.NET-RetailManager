using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {

            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();

            foreach(var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                var taxRate = ConfigHelper.GetTaxRate() / 100;

                var productInfo = products.GetProductById(detail.ProductId);

                if(productInfo == null)
                {
                    throw new Exception($"The product Id of {detail.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }
                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x =>  x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            using(SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("TRMData");

                    sql.SaveDataInTransaction("dbo.spSaleInsert", sale);



                    sale.Id = sql.LoadDataInTransaction<int, dynamic>("spSaleLookup", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;
                        sql.SaveDataInTransaction("dbo.spSaleDetailInsert", item);
                    }

                    sql.CommitTransaction();
                }
                catch
                {
                    sql.RollbackTransaction();
                    throw;
                }

            }





        }
    }
}
