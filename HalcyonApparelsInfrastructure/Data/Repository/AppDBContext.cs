using HalcyonApparelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsInfrastructure.Data.Repository
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<AdminLogin> AdminLogin
        {
            get; set;
        }

        public DbSet<LoginCredentials> LoginCredentials
        {
            get; set;
        }

        public DbSet<AccessoryDetails> AccessoryDetails
        {
            get; set;
        }

        public DbSet<CustomerDetails> CustomerDetails
        {
            get; set;
        }

        public DbSet<OrderDetails> OrderDetails
        {
            get; set;
        }


        public DbSet<ProductType> Products
        {
            get; set;
        }


        public DbSet<CustomerMarketing> CustomerMarketing
        {
            get; set;
        }

    }
}
