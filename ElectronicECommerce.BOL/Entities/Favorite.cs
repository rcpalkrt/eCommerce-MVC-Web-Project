using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("Favorite")]
    public class Favorite
    {
        [Key,Column(Order =1)]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Key, Column(Order = 2)]
        public int MemberID { get; set; }
        public Member Member { get; set; }
    }
}
