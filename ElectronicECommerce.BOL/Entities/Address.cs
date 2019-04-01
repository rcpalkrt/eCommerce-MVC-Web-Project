using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Address")]
    public class Address
    {
        public int ID { get; set; }
        public int MemberID { get; set; }

        [StringLength(30), Column(TypeName = "varchar"), Display(Name = "Adres Adı")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Adresi")]
        public string MemberAddress { get; set; }

        public int CityID { get; set; }
        public int DistrictID { get; set; }

        public City City { get; set; }
        public District District { get; set; }
        public Member Member { get; set; }
    }
}
