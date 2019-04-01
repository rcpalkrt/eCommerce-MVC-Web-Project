using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("SalesDetail")]
    public class SalesDetail
    {
        [Key, Column(Order = 1)]
        public int SaleID { get; set; }

        [Key, Column(Order = 2)]
        public int ProductID { get; set; }

        [Display(Name = "Adet")]
        public int? Quantity { get; set; }

        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name = "İndirim")]
        public double? Off { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
