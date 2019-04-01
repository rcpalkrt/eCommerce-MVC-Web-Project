using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar"), Display(Name = "Sipariş Adı"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar"), Display(Name = "Sipariş Açıklması"), Required(ErrorMessage = "Boş Geçilemez.")]
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
