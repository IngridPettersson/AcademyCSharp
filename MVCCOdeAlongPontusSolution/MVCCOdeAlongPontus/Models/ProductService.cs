using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCOdeAlongPontus.Models
{
    public class ProductService
    {
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Toothbrush", Price = 30 },
            new Product { Id = 2, Name = "Milk", Price = 15 },
            new Product { Id = 3, Name = "Bread", Price = 40 }

        };

        // Det här skulle lika gärna kunna vara en SQL-fråga mot databasen. LINQ-frågorna kommer då se ut exakt såhär.
        public Product[] GetAll()
        {
            return products
                .OrderBy(o => o.Name)
                .ToArray();
        }
    }
}
