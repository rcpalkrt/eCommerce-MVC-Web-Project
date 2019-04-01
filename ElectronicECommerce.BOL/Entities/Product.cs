using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Ürün Adı")]
        public string Name { get; set; } 

        [Column(TypeName = "text"), Display(Name = "Ürün Detayları")]
        public string Detail { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int PIndex { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        [Display(Name = "Ürün Yeni Mi?")]
        public bool IsNew { get; set; }

        [Display(Name = "Ürün İndirimli Mi?")]
        public bool IsDiscount { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Eklenme Tarihi")]
        public DateTime? InsertDate { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Ürün Resmi")]
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
