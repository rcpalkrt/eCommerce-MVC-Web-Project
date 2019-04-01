using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.WEBUI.ViewModels
{
    public class ProductVM
    {
        public ICollection<Category> categories { get; set; }
        public ICollection<Brand> brands { get; set; }
        public ICollection<Product> products { get; set; }
        public ICollection<Product> relatedProducts { get; set; }
        public Product detailProduct { get; set; }
    }
}