using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MarketMVC.Models;

namespace MarketMVC.ViewModel
{
    public class CreateProduct
    {
        public Product Product { get; set; }

        [Required(ErrorMessage ="Please Mate")]
        public HttpPostedFileBase Pic { get; set; }
    }
}