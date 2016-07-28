using System;
using Task2.north;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Collections;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (NorhWd context = new NorhWd())
            {



                var query1 = context.Customers.Where(c => c.ContactName.StartsWith("D")).Select(res => res.ContactName);

                // var query2 = context.Customers.Select(c => UpperName(c));

                // //or 

                var query2 = context.Customers.Select(c => c.ContactName.ToUpper());
                var query3 = context.Customers.Select(c => c.Country).Distinct();


                var query4 = context.Customers.Where(c => c.City.Equals("London")).Where(c => c.ContactTitle.StartsWith("Sales")).Select(res=>res.ContactName);

                var query5 = context.OrderDetails.Include(od => od.Product).Where(od => od.Product.ProductName.Equals("Tofu")).Select(res=>res.OrderId+"");
                var query6 = context.Orders.Include(od => od.OrderDetails)
                        .Where(or => or.ShipCountry.Equals("Germany"))
                            .SelectMany(or => or.OrderDetails.Select(orderD => orderD.Product.ProductName)).Distinct();


                var query7 = context.OrderDetails.Include(details => details.Order)
                                                        .ThenInclude(oreder => oreder.Customer)
                                                .Include(details => details.Product)
                                                .Where(details => details.Product.ProductName.Equals("Ikura"))
                                                .Select(details => new {details.Order.Customer.CustomerId,details.Order.Customer.ContactName}).Distinct();
                var query8 =from emplo in  context.Employees join order in context.Orders on emplo.EmployeeId equals order.EmployeeId into temp
                                from c in temp.DefaultIfEmpty() 
                                select new {c.EmployeeId,c.OrderId};
                var query9 =(from order in  context.Orders join emplo in context.Employees on order.EmployeeId equals emplo.EmployeeId   into temp
                                from c in temp.DefaultIfEmpty() 
                                select new {c.EmployeeId,Orders=String.Join(" ",c.Orders.Select(o=>o.OrderId.ToString()))}).Distinct();
        

                var query10 = context.Shippers.Select(sh => "Shippers phome " + sh.Phone).Union(context.Suppliers.Select(su => "Supplier Phone " + su.Phone));

                var query11 = from cust in context.Customers group cust by cust.City into temp select new { City = temp.Key, CustCount = temp.Count() };

                var query12 = from cust in context.Orders.Include(order => order.Customer).Include(order => order.OrderDetails).GroupBy(order => order.Customer)
                              where cust.Where(order => order.OrderDetails.Average(det => double.Parse(det.UnitPrice)) < 17)
                                        .Count() > 10
                              select new { CustName = cust.Key.ContactName };

                var query13 = context.Customers.Where(cust => Regex.IsMatch(cust.Phone, @"^[0-9]{4}-[0-9]{4}$")).Select(res => res.Phone);


                var query14 = (from order in context.Orders
                               join orderDetails in context.OrderDetails on order.OrderId equals orderDetails.OrderId
                               group orderDetails by order.CustomerId into temp
                               select new { Customer = temp.Key, Count = temp.Count() }).OrderByDescending(res => res.Count).First();




                var query15 = from customer in context.Customers
                              where (from order in context.Orders
                                     join orderDetails in context.OrderDetails on order.OrderId equals orderDetails.OrderId
                                     where order.CustomerId.Equals("FAMIA")
                                     select orderDetails.ProductId)
                                      .Except((
                                      from order in context.Orders
                                      join orderDetails in context.OrderDetails on order.OrderId equals orderDetails.OrderId
                                      where order.CustomerId == customer.CustomerId
                                      select orderDetails.ProductId)).Count() == 0
                              select customer.CustomerId;




                print(query1,1);
                print(query2,2);
                print(query3,3);
                print(query4,4);
                print(query5,6);
                print(query6,6);
                print(query7,7);
                print(query8,8);

                print(query9,9);
               print(query10,10);
                print(query11,11);
                print(query12,12);
                print(query13,13);
                System.Console.WriteLine("query 14");
                System.Console.WriteLine(query14);
                print(query15,15);

           
            }

        }
        public static void print(IQueryable<dynamic> queries,int q)
    
        {
            System.Console.WriteLine("query number :"+q);
            foreach (var item in queries)
            {
                System.Console.WriteLine(item);
            }

        }
        public static Customers UpperName(Customers c)
        {
            c.ContactName = c.CompanyName.ToUpper();
            return c;
        }
    }
}
