using Linq02Assignment.Data;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using static Linq02Demo.ListGenerator;
namespace Linq02Assignment
{
    internal class Program
    {
        static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {

                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators
            #region 1. Find all products that are out of stock.
           var ProductsOutOfStock= ProductsList.Where(p => p.UnitsInStock == 0);
            //PrintCollection(ProductsOutOfStock);
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            var products = ProductsList.Where(p => p.UnitsInStock >0 && p.UnitPrice>3);
            //PrintCollection(products);
            #endregion
           
            #region 3. Returns digits whose name is shorter than their value.
            String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result =Arr.Where((a, i) => a.Length < i);
            //PrintCollection(result);
            #endregion
            #endregion

            #region  LINQ - Element Operators

            #region 1. Get first Product out of Stock 
            var FristProductOutOfStock= ProductsList.First(p => p.UnitsInStock == 0);
            //Console.WriteLine(FristProductOutOfStock);
            #endregion


            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned
            var product = ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(product);
            #endregion

            #region 3. Retrieve the second number greater than 5 
            int[] Arrr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var element=Arrr.Where(n=>n>5).ElementAt(1);
            //Console.WriteLine(element);
            #endregion
            #endregion

            #region LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array
            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int count=arr.Count(n=>n%2==1);
            //Console.WriteLine(count);
            #endregion

            #region 2. Return a list of customers and how many orders each has.
            
            var CustomerCount=CustomersList.SelectMany(c => c.Orders).Count();
            //Console.WriteLine(CustomerCount);
            #endregion

            #region 3. Return a list of categories and how many products each has
            var categories = from p in ProductsList
                         group p by p.Category into g
                         select new
                         {
                             Category = g.Key,
                             Count = g.Count()
                         };

            //PrintCollection(categories);
            #endregion

            #region 4.Get the total of the numbers in an array.
            int[] Array = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int SumofElements = Array.Sum();
            //Console.WriteLine(SumofElements);
            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");

            var sumofTotalChars=words.Sum(n=>n.Length);
            //Console.WriteLine(sumofTotalChars);
            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var ShortestLength= words.Min(n=>n.Length);
            //Console.WriteLine(ShortestLength);
            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var LongestLength = words.Max(n => n.Length);
            //Console.WriteLine(LongestLength);
            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var AvgLength = words.Average(n => n.Length);
            //Console.WriteLine(AvgLength);
            #endregion


            #region 9. Get the total units in stock for each product category.
            
            var UnitsInStockPerCategory= from p in ProductsList
                                         group p by p.Category into g
                                         select new
                                         {
                                             Category = g.Key,
                                             UnitsInStock = g.Sum(p=>p.UnitsInStock)
                                         };
            //PrintCollection(UnitsInStockPerCategory);
            #endregion

            #region 10. Get the cheapest price among each category's products

            var CheapestPricePerCategory= from p in ProductsList
                                          group p by p.Category into g
                                          select new
                                          {
                                              Category = g.Key,
                                              CheapestPrice = g.MinBy(p=>p.UnitPrice)?.UnitPrice
                                          };
            //PrintCollection(CheapestPricePerCategory);
            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let)

            var CheapestPriceProductsPerCategory= from p in ProductsList
                                      group p by p.Category into g
                                      let CheapestProduct = g.MinBy(p => p.UnitPrice)

                                      select new
                                      {
                                          Category = g.Key,
                                          CheapestProduct
                                      };
            //PrintCollection(CheapestPriceProductsPerCategory);
            #endregion

            #region 12. Get the most expensive price among each category's products.

            var MostExpensivePricePerCategory = from p in ProductsList
                                       group p by p.Category into g
                                       let MostExpensivePrice = g.MaxBy(p => p.UnitPrice)?.UnitPrice

                                       select new
                                       {
                                           Category = g.Key,
                                           MostExpensivePrice
                                       };
            //PrintCollection(MostExpensivePricePerCategory);
            #endregion

            #region 13. Get the products with the most expensive price in each category.
            var MostExpensiveProductPerCategory = from p in ProductsList
                                                group p by p.Category into g
                                                let MostExpensiveProduct = g.MaxBy(p => p.UnitPrice)

                                                select new
                                                {
                                                    Category = g.Key,
                                                    MostExpensiveProduct
                                                };
            //PrintCollection(MostExpensiveProductPerCategory);
            #endregion

            #region 14. Get the average price of each category's products.
            var avgPrice = from p in ProductsList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               avgPrice = g.Average(p => p.UnitPrice)
                           };
            //PrintCollection(avgPrice);
            #endregion


            #endregion
        }
    }
}
