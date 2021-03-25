using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models
{
    public class MyIdentityContext : IdentityDbContext<MyIdentityUser>
    {
        public MyIdentityContext(DbContextOptions<MyIdentityContext> options)
            : base(options)
        {
            //Man måste skapa en tom databas för att detta ska gå igenom
            Database.EnsureCreated();
        }
    {
    }
}
