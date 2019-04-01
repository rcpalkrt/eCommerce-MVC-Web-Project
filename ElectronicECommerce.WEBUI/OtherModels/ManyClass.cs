using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicECommerce.BOL.Entities;

namespace ElectronicECommerce.WebUI.OtherModels
{
    public class ManyClass
    {
        public Product Product { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}