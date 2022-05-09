using LCWAssessment.Global.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWAssessment.Data.EF
{
    public class LCWDbContext : DbContext
    {

        public LCWDbContext(DbContextOptions<LCWDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x => { x.HasKey(z => new { z.CustomerId }); });
            modelBuilder.Entity<CustomerOrder>(x => { x.HasKey(z => new { z.OrderNumber }); });
            modelBuilder.Entity<CustomerOrderDetail>(x => { x.HasKey(z => new { z.CustomerOrderDetailId }); });
            modelBuilder.Entity<Product>(x => {x.HasKey(z => new { z.ProductId });});           

            base.OnModelCreating(modelBuilder);
        }

        



    }
}
