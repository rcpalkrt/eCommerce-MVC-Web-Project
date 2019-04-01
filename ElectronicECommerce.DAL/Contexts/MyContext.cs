using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.DAL.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext():base("CS"){}

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
