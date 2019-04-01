using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Şirket Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string CompanyName { get; set; }

        [StringLength(250), Column(TypeName = "varchar"), Display(Name = "Şirket Adresi"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Address { get; set; }

        [StringLength(20), Column(TypeName = "varchar"), Display(Name = "Şirket Telefonu"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string PhoneNumber { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Şirket Websitesi"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Website { get; set; }

        [StringLength(50), Column(TypeName = "varchar"), Display(Name = "Şirket Email"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
