using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketMVC.Models
{
    public class Product
    {
        public int ID { get; set; }

        public byte[] Pic { get; set; }

        [Required(ErrorMessage = "Necessary")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only Letters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Necessary")]
        [RegularExpression("^[A-Za-z ]+$",ErrorMessage ="Only Letters")]
        public string Brand { get; set; }

        
        [Required(ErrorMessage ="Necessary")]
        public decimal Price { get; set; }

        public string Tag { get; set; }
    }
}