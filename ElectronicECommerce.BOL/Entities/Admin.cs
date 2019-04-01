using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Admin")]
    public class Admin
    {
        [Key, StringLength(50), Column(TypeName = "varchar"), Display(Name = "Kullanıcı Ad"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string UserName { get; set; }

        [StringLength(50), Column(TypeName = "varchar"), Display(Name = "Yetkili Ad Soyad"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Name { get; set; }

        [StringLength(20), Column(TypeName = "varchar"), Display(Name = "Şifre"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Password { get; set; }

        [NotMapped, Compare("Şifre", ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string Password2 { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Son Giriş Tarihi")]
        public DateTime LastEntryDate { get; set; }

        [StringLength(20), Column(TypeName = "varchar"), Display(Name = "Son Giriş IP Adres")]
        public string LastEntryIP { get; set; }

        [StringLength(20), Column(TypeName = "Varchar"), Display(Name = "Rolü")]
        public string Rol { get; set; }
    }
}
