using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.DAL.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyDbContext")
        {
            Database.SetInitializer<MyDbContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<ServiceSubCategory>().ToTable("ServiceSubCategory");
            modelBuilder.Entity<ServiceSpecifications>().ToTable("ServiceSpecifications");
            modelBuilder.Entity<ServiceAdMaster>().ToTable("ServiceAdMaster");
            modelBuilder.Entity<ServiceCategory>().ToTable("ServiceCategory");
            modelBuilder.Entity<ServiceImages>().ToTable("ServiceImages");
            modelBuilder.Entity<ServiceReviews>().ToTable("ServiceReviews");
            modelBuilder.Entity<ServiceSecificationsPosted>().ToTable("ServiceSecificationsPosted");
            modelBuilder.Entity<StateMaster>().ToTable("StateMaster");
            modelBuilder.Entity<CountryMaster>().ToTable("CountryMaster");
            modelBuilder.Entity<CityMaster>().ToTable("CityMaster");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<CustomerAddresses>().ToTable("CustomerAddresses");
            modelBuilder.Entity<CustomerPassword>().ToTable("CustomerPassword");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<AddTypeMaster>().ToTable("AddTypeMaster");
            modelBuilder.Entity<OpeningDays>().ToTable("OpeningDays");





        }
    }
}
