﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int QuantityInCart { get; set; }
        public string DisplayText
        {
            get
            {

                string count = QuantityInCart == 1 ? string.Empty : $"({QuantityInCart.ToString()})";
                return $"{Product.ProductName} {count}";
            }
        }
    }
}
