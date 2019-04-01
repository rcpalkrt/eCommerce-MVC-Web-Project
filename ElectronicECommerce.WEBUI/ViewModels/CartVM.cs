using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.WEBUI.ViewModels
{
    public class CartVM
    {
        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<Product> BestSellerProducts { get; set; }
    }
}