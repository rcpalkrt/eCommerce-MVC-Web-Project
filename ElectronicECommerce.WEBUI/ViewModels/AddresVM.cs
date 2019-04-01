using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.WEBUI.ViewModels
{
    public class AddresVM
    {
        public ICollection<Address> addresses { get; set; }
        public ICollection<City> cities { get; set; }
        public Address address { get; set; }
    }
}