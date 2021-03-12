/*
 Entity Framework (EF) är en ORM = Object Relational Mapper - SQL-tabeller i form av C#-klasser - LINQ
^
|
ADO.NET (Active Data Objects .NET)
^
|
SQL Server
 
 */



using EntityFrameworkDemoHakan.Models.Entities;
using System;
using System.Linq;

namespace EntityFrameworkDemoHakan
{
    class Program
    {
        static void Main(string[] args)
        {
            MercuryContext mercury = new MercuryContext();

            //Product product = new Product()
            //{
            //    ProductName = "ETTAN",
            //    Price = 51.0m
            //};

            //mercury.Products.Add(product);
            //mercury.SaveChanges();


            var productToUpdate = mercury.Products
                .FirstOrDefault(o => o.ProductName.ToLower() == "ettan");

            //if(productToUpdate != null)
            //{
            //productToUpdate.Price *= 0.9m;
            //mercury.SaveChanges();
            //}

            bool done = false;
            while (!done)
            {
                HistoricalPrice hp = mercury
                    .HistoricalPrices
                    .FirstOrDefault(p => p.ProductsId == productToUpdate.Id);

                done = hp == null;

                if(!done)
                {
                    mercury.HistoricalPrices.Remove(hp);
                    mercury.SaveChanges();
                }
            }

            mercury.Products.Remove(productToUpdate);
            mercury.SaveChanges();
        }
    }
}
