using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("Image")]
    public class Image
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Görüntü Yolu"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string ImagePath { get; set; }

        [Display(Name = "Görüntü Sırası"), Required(ErrorMessage = "Boş Geçilemez.")]
        public int ImageOrder { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
