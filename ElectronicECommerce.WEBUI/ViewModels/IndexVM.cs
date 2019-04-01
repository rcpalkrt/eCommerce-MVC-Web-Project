using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicECommerce.BOL.Entities;

namespace ElectronicECommerce.WebUI.ViewModels
{
    public class IndexVM
    {
        public ICollection<Product> products { get; set; }
        public ICollection<Product> NewestProducts { get; set; }
        public ICollection<Product> BestSellerProducts { get; set; }
        public ICollection<Picture> pictures { get; set; }
        public List<Advertisement> advertisements { get; set; }
    }
}