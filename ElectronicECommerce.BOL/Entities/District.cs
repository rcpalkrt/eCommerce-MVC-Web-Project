using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("District")]
    public class District
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar"), Display(Name = "Adı")]
        public string Name { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }
    }
}