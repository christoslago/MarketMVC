using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketMVC.Models;

namespace MarketMVC.Services
{
    public static class EditProduct
    {
        public static Product EditMe(Product x,Product y)
        {
            if (!string.IsNullOrEmpty(y.Name))
            {
                x.Name = y.Name;
            }
            if (!string.IsNullOrEmpty(y.Brand))
            {
                x.Brand = y.Brand;
            }
            if (!string.IsNullOrEmpty(y.Tag))
            {
                x.Tag = y.Tag;
            }
            x.Price = y.Price;
            if (y.Pic != null)
            {
                x.Pic = y.Pic;
            }
            return x;
        }
    }
}