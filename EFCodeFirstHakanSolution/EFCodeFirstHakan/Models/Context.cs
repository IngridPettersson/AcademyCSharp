using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstHakan.Models
{
    class Context : DbContext
    {
        //Databasnamnet ska nog inte ha parentes om sig
        string connectionString = @"Server=(localdb)\MsSqlLocalDb;Database=(MyProductDB);Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
