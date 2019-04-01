using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Picture")]
    public class Picture
    {
        public int ID { get; set; }
        public int PIndex { get; set; }
        public int ProductID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Sepetteki Resim")]
        public string PCartPath { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Ürün Detay Resim")]
        public string PDetailPath { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Son Eklenen Ürün Resim")]
        public string PLastSliderPath { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Slayt Resim")]
        public string PSliderPath { get; set; }

        [Display(Name = "Görüntülenme Sırası")]

        public virtual Product Product { get; set; }
    }
}
