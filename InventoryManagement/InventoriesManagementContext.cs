using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Controllers;

namespace InventoryManagement
{
    public class InventoriesManagementContext : DbContext
    {
            public DbSet<Inventories> Inventory { get; set; }
            public DbSet<Orders> Order { get; set; }
            public DbSet<OrderDetails> OrderDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            //optionsBuilder
            //    .UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=InventoryManagement;User Id=sa;Password=123abcde!;");


            optionsBuilder
                   .UseSqlServer(@"Data Source=localhost,1401;Initial Catalog=InventoryManagement;User Id=SA;Password=YourStrong!Passw0rd;");
        }
    }
}
