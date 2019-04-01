using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("Sale")]
    public class Sale
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Satış Tarihi"), Required(ErrorMessage = "Boş Geçilemez.")]
        public DateTime SellingDate { get; set; }

        [Display(Name = "Toplam Tutar"), Required(ErrorMessage = "Boş Geçilemez.")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Sepette Mi?"), Required(ErrorMessage = "Boş Geçilemez.")]
        public bool InCart { get; set; }

        public int? CargoID { get; set; }
        public int? OrderStatusID { get; set; }

        [StringLength(50), Column(TypeName = "varchar"), Display(Name = "Ürün Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string CargoTrackingNumber { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
