using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketMVC.Models;

namespace MarketMVC.ViewModel
{
    public class EditProduct
    {
        public Product Product { get; set; }

        public HttpPostedFileBase Pic { get; set; }

        public List<SelectListItem> listItems = new List<SelectListItem>();

        public EditProduct()
        {
            listItems.Add(new SelectListItem
            {
                Text = "Τυροκομικά",
                Value = "Τυροκομικά"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Αλλαντικά",
                Value = "Αλλαντικά"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Είδη Υγιεινής",
                Value = "Είδη Υγιεινής"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Αηδίες",
                Value = "Αηδίες"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Περιποίηση Σώματος",
                Value = "Περιποίηση Σώματος"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Μαναβική",
                Value = "Μαναβική"
            });
        
    
        }
    }
}