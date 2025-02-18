using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {

        [Authorize(Roles = "Cashier")]

        public void Post(SaleModel sale)
        {
            SaleData saleData = new SaleData();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // RequestContext.Principal.Identity.GetUserId();

            saleData.SaveSale(sale, userId);
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleData data = new SaleData();

            return data.GetSaleReport();
        }
    }
}
