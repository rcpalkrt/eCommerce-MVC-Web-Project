using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Müşteri Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Name { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Müşteri Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Surname { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string UserName { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Email Adresi"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Email { get; set; }

        [StringLength(20), Column(TypeName = "varchar"), Display(Name = "Müşteri Telefon"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
