using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("PropertyType")]
    public class PropertyType
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Özellik Tipi"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Name { get; set; }

        [StringLength(250), Column(TypeName = "varchar"), Display(Name = "Özellik Açıklaması"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Description { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<PropertyValue> PropertyValues { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
