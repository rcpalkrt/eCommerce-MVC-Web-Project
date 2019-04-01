using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("CustomerAddress")]
    public class CustomerAddress
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar"), Display(Name = "Müşteri Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string AddressName { get; set; }

        [StringLength(500), Column(TypeName = "varchar"), Display(Name = "Müşteri Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Address { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
