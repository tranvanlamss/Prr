using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RechargeOnline.Models
{
    public class DataContext : DbContext
    {

        public DataContext() : base("RechargeOnline")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks  { get; set; }
        public DbSet<Oder> Oders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<feedback> feedbacks { get; set; }
        public System.Data.Entity.DbSet<RechargeOnline.Models.Categorie> categories { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<account_balance> account_Balances { get; set; }
    }
}