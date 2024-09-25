using Microsoft.EntityFrameworkCore;
using taskLinqu.Data;
using taskLinqu.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace taskLinqu
{
  internal class Program
  {
    static void Main(string[] args)
    {
      ApplicationDbContext context = new ApplicationDbContext();
      //Retrieve all categories from the production.categories table.
      var categories = context.Categories.ToList();
      foreach (var category in categories)
      {
        Console.WriteLine(category.CategoryName);
      }
      Console.WriteLine("=================");
      //Retrieve the first product from the production.products table.
      var products = context.Products.ToList();
      Console.WriteLine(products.FirstOrDefault().ProductName);
      Console.WriteLine("=================");
      //Retrieve a specific product from the production.products table by ID.
      Console.WriteLine(products.Find(e => e.ProductId == 5).ProductName);
      Console.WriteLine("=================");
      //Retrieve all products from the production.products table with a certain model year.
      var products2017 = products.Where(e => e.ModelYear == 2017);
      foreach (var p in products2017)
      {
        Console.WriteLine($"Name: {p.ProductName}  year: {p.ModelYear}");
      }
      Console.WriteLine("=================");
      //Retrieve a specific customer from the sales.customers table by ID.
      Customer customer = context.Customers.Find(5);
      Console.WriteLine("customer Name: " + customer.FirstName);
      Console.WriteLine("=================");
      //Retrieve a list of product names and their corresponding brand names.
      products = context.Products.Include(e => e.Brand).ToList();
      foreach (var p in products)
      {
        Console.WriteLine($"product name: {p.ProductName}  brand name: {p.Brand.BrandName}");
      }
      Console.WriteLine("=================");
      //Count the number of products in a specific category.
      var countProduct = products.Where(e => e.CategoryId == 3).Count();
      Console.WriteLine(countProduct);
      Console.WriteLine("=================");
      //Calculate the total list price of all products in a specific category.
      var totalPrice = products.Where(e => e.CategoryId == 2).Sum(e => e.ListPrice);
      Console.WriteLine(totalPrice);
      Console.WriteLine("=================");
      //Calculate the average list price of products.
      var avg = products.Average(e => e.ListPrice);
      Console.WriteLine(avg);
      Console.WriteLine("=================");
      //Retrieve orders that are completed.
      var completeOrders = context.Orders.Where(e => e.OrderStatus == 2);
      foreach (var order in completeOrders)
      {
        Console.WriteLine(order.OrderId);
      }
    }
  }
}
