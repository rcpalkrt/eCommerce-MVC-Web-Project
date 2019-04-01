using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Member")]
    public class Member
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar"), Display(Name = "Adı")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar"), Display(Name = "Soyadı")]
        public string SurName { get; set; }

        [StringLength(80), Column(TypeName = "varchar"), Display(Name = "Mail Adresi")]
        public string MailAddress { get; set; }

        [StringLength(20), Column(TypeName = "varchar"), Display(Name = "Telefonu")]
        public string PhoneNumber { get; set; }

        [StringLength(80), Column(TypeName = "varchar"), Display(Name = "Şifre")]
        public string Password { get; set; }

        [NotMapped, Display(Name = "Şifre Tekrar")]
        public string Password2 { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Son Giriş Tarihi")]
        public DateTime LastDate { get; set; }

        [StringLength(20), Column(TypeName = "Varchar"), Display(Name = "Son Giriş IP Adresi")]
        public string LastIP { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
