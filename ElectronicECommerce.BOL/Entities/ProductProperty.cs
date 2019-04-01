using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.Models
{
    [Table("ProductProperty")]
    public class ProductProperty
    {
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        [Key, Column(Order = 2)]
        public int PropertyTypeID { get; set; }
        [Key, Column(Order = 3)]
        public int PropertyValueID { get; set; }

        public virtual Product Product { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertyValue PropertyValue { get; set; }
    }
}
