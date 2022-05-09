using LCWAssessment.Data.EF;
using LCWAssessment.Global.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCWAssessment.Data
{
    public class DbInitializer
    {
        public static void Initialize(LCWDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            AddProduct(context);
            AddCustomer(context);
            AddCustomerOrder(context);
            AddCustomerOrderDetail(context); 

            context.SaveChanges();
   
        }


        private static void AddProduct(LCWDbContext context)
        {
            var products = new List<Product>
            {
            new Product{ Barcode = 1000 , Description = "Description1" , ColorCode = 5 , ProductName = "ProductName1" , Weight  = 1  },
            new Product{ Barcode = 1001 , Description = "Description2" , ColorCode = 25 , ProductName = "ProductName2" , Weight  = 1  },
            new Product{ Barcode = 1002 , Description = "Description3" , ColorCode = 125 , ProductName = "ProductName3" , Weight  = 1  },
            new Product{ Barcode = 1003 , Description = "Description4" , ColorCode = 625 , ProductName = "ProductName4" , Weight  = 1  },
            };

            foreach (Product product in products)
            {
                context.Products.Add(product);
            }

            var result = context.SaveChanges();
        }
        private static void AddCustomer(LCWDbContext context)
        {
            var customers = new List<Customer>
            {
               new Customer{ CustomerName = "LCWUser1" , Address = "LCWAddressInfo1"},
               new Customer{ CustomerName = "LCWUser2" , Address = "LCWAddressInfo2"},
               new Customer{ CustomerName = "LCWUser3" , Address = "LCWAddressInfo3"},
               new Customer{ CustomerName = "LCWUser4" , Address = "LCWAddressInfo4"},
               new Customer{ CustomerName = "LCWUser5" , Address = "LCWAddressInfo5"},
            };

            foreach (Customer customer in customers)
            {
                context.Customers.Add(customer);
            }

            var result = context.SaveChanges();


        }
        private static void AddCustomerOrder(LCWDbContext context)
        {
            var customerOrders = new List<CustomerOrder>
            {
               new CustomerOrder{ CustomerId = 1 , OrderStatus = 1},
               new CustomerOrder{ CustomerId = 1 , OrderStatus = 2},
               new CustomerOrder{ CustomerId = 1 , OrderStatus = 3},
               new CustomerOrder{ CustomerId = 1 , OrderStatus = 4},
               new CustomerOrder{ CustomerId = 1 , OrderStatus = 5},
            };

            foreach (CustomerOrder customerOrder in customerOrders)
            {
                context.CustomerOrders.Add(customerOrder);
            }

            var result = context.SaveChanges();
        }
        private static void AddCustomerOrderDetail(LCWDbContext context)
        {
            var customerOrderDetails = new List<CustomerOrderDetail>
            {
               new CustomerOrderDetail{ CustomerOrderId = 1 , Barcode = 100200300 , Price = 500 , Quantity = 2 },
               new CustomerOrderDetail{ CustomerOrderId = 1 , Barcode = 100200301 , Price = 500 , Quantity = 2 },
               new CustomerOrderDetail{ CustomerOrderId = 1 , Barcode = 100200302 , Price = 500 , Quantity = 2 },
               new CustomerOrderDetail{ CustomerOrderId = 1 , Barcode = 100200303 , Price = 500 , Quantity = 2 },
               new CustomerOrderDetail{ CustomerOrderId = 1 , Barcode = 100200304 , Price = 500 , Quantity = 2 },
            };

            foreach (CustomerOrderDetail customerOrderDetail in customerOrderDetails)
            {
                context.CustomerOrderDetails.Add(customerOrderDetail);
            }

            var result = context.SaveChanges();
        }



    }

}

