using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("City")]
    public class City
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar"), Display(Name = "Adı")]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}