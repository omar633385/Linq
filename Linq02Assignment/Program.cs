using System.Collections;
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
        }
    }
}
