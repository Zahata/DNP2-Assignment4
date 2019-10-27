using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product() { Name = "Milk", Price = 10 };
            Product p2 = new Product() { Name = "Butter", Price = 20 };
            Product p3 = new Product() { Name = "Bread", Price = 7 };
            Product p4 = new Product() { Name = "Cacao", Price = 25 };
            Product p5 = new Product() { Name = "Juice", Price = 10 };

            Order order1 = new Order() { Quantity = 1, Product = p1 };
            Order order2 = new Order() { Quantity = 1, Product = p2 };
            Order order3 = new Order() { Quantity = 1, Product = p3 };
            Order order4 = new Order() { Quantity = 1, Product = p4 };
            Order order5 = new Order() { Quantity = 1, Product = p5 };

            Customer customer1 = new Customer() { Name = "Kim Foged", City = "Beder", Orders = new Order[] { order1, order2, order3 } };
            Customer customer2 = new Customer() { Name = "Ib Havn", City = "Horsens", Orders = new Order[] { order1, order2, order3, order4 } };
            Customer customer3 = new Customer() { Name = "Rasmus Bjerner", City = "Horsens", Orders = new Order[] { order5 } };

            List<Customer> customersList = new List<Customer>() { customer1,
                                                                  customer2,
                                                                  customer3 };

            #region Printing Name and City of all Customers
            var customers = from c in customersList
                            select new { c.Name, c.City };
            foreach (var i in customers) {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            #endregion

            #region Printing the Names of all customers from Horsens
            var horsensCustomers = from c in customersList
                                   where c.City == "Horsens"
                                   select new { c.Name };
            foreach (var i in horsensCustomers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            #endregion
            #region Printing count of orders for Ib Havn
            var orders = from c in customersList
                         where c.Name == "Ib Havn"
                         select new { c.Orders.Length };
            foreach (var i in orders)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            #endregion
            #region Printing customers buying milk
            var milkOrder = from c in customersList
                            from o in c.Orders
                            where o.Product.Name == "Milk"
                            select new { c.Name };
            foreach (var i in milkOrder)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            #endregion
            #region Print Name and Sum of each customer
            var nameAndSum = from c in customersList
                             group c by c.Name into g
                             select new
                             {
                                 Name = g.Key,
                                 Sum = (from c in g
                                        from o in c.Orders
                                        select o.Product.Price).Sum()
                             };
            foreach (var i in nameAndSum)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            #endregion
            #region Print total sum of all customers orders
            var result = (from c in customersList
                          from o in c.Orders
                          select o.Product.Price).Sum();
            Console.WriteLine(result);
            Console.WriteLine("");
            #endregion
            Console.ReadKey();
        }
    }
}
