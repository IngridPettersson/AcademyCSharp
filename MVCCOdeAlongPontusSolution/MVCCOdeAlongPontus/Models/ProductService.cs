using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCOdeAlongPontus.Models
{
    public class ProductService
    {
        private readonly MyContext myContext;
        public ProductService(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // Fake-databas
        //static List<Product> products = new List<Product>
        //{
        //    new Product { Id = 1, Name = "Toothbrush", Price = 30 },
        //    new Product { Id = 2, Name = "Milk", Price = 15 },
        //    new Product { Id = 3, Name = "Bread", Price = 40 }

        //};

        // Det här skulle lika gärna kunna vara en SQL-fråga mot databasen. LINQ-frågorna kommer då se ut exakt såhär.
        public Product[] GetAll()
        {
            //var sql = "select * from Product order by Name";
            return myContext.products
                .OrderBy(o => o.Name)
                .ToArray();
        }

        internal void Add(Product product)
        {
            myContext.Products.Add(product);
        }
    }
}
