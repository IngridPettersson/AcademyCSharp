using EFCodeFirstHakan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCodeFirstHakan
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            //RemoveProduct(context, "Granit");
            //UpdateProducts(context, "General", "General White");
            UpdateProduct(context, "General White", "General");

            //ListAllProducts();
            //ListProduct("Granit");

            //AddProduct(context, "Granit");
            //AddProduct(context, "General");
            //AddProduct(context, "Lyft");

            //AddCustomer(context, "ACME", "08-123 45 67");
            //AddCustomerAddress(context, "ACME", "Borgarfjordsgatan 4 132 44 Kista");


            //Customer address = context.Customers
            //    .Include("CustomerAddresses")
            //    .FirstOrDefault(c => c.Id == 1);
        }

        private static void UpdateProduct(Context context, string productName, string newProductName)
        {
            var product = context.Products.FirstOrDefault(p => p.Name == productName);

        }

        private static void UpdateProducts(Context context, string productName, string newProductName)
        {
            var products = context.Products.Where(p => p.Name == productName);
            
                foreach (var p in products)
                {
                    p.Name = newProductName;
                }
            context.SaveChanges();
        }

        private static void RemoveProduct(Context context, string productName)
        {
            var product = context.Products.FirstOrDefault(o => o.Name == productName);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        private static void AddCustomerAddress(Context context, string customerName, string streetCityZip)
        {
            Customer cust = context.Customers
                .FirstOrDefault(o => o.CustomerName == customerName);

            if (cust.CustomerAddresses == null)
            {
                cust.CustomerAddresses = new List<CustomerAddress>();
            }
            cust.CustomerAddresses.Add(new CustomerAddress { CustomerId = cust.Id, StreetCityZip = streetCityZip });
            context.SaveChanges();
        }

        private static void AddCustomer(Context context, string customerName, string customerPhoneNr)
        {
            context.Customers.Add(new Customer
            {
                CustomerName = customerName,
                PhoneNumber = customerPhoneNr
            });
            context.SaveChanges();
        }

        private static void AddProduct(Context context, string productName)
        {
            context.Products.Add(new Product { Name = productName });
            context.SaveChanges();
        }
    }
}
