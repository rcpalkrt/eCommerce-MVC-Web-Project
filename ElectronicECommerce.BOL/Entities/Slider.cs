using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Slider")]
    public class Slider
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Slayt Resmi")]
        public string Picture { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Üst Başlık")]
        public string Title { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Alt Başlık")]
        public string SubTitle { get; set; }

        [StringLength(250), Column(TypeName = "varchar"), Display(Name = "Slayt Açıklaması")]
        public string Description { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Ürün Linki")]
        public string ProductLink { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int PIndex { get; set; }

    }
}
