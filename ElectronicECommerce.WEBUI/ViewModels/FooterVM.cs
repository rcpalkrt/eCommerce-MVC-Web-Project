using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicECommerce.WEBUI.ViewModels
{
    public class FooterVM
    {
        public ICollection<Category> categories { get; set; }
        public ICollection<Brand> brands { get; set; }
        public ICollection<QuestionCategory> questionCategories { get; set; }
    }
}