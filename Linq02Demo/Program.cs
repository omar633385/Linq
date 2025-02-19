using System.Collections;
using System.Security.Cryptography;
using static Linq02Demo.ListGenerator; // wrote static to use all things in ListGenerator Class instead of writing class name every time to use anything from it
namespace Linq02Demo
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
            #region DataSetup

            //Console.WriteLine(ProductsList[0]);
            //Console.WriteLine(CustomersList[0]);
            #endregion

            #region Filteration-Operators

            #region Get Elements Out Of Stock
            //fluent syntax
            //var result= ProductsList.Where(p=>p.UnitsInStock==0);

            // //query syntax
            // result= from p in ProductsList
            //         where p.UnitsInStock==0
            //         select p;

            //PrintCollection(result);

            #endregion

            #region Get Elements In Stock And In Category Of Meat/Poultry
            //fluent syntax
            //var result=ProductsList.Where(p => p.UnitsInStock > 0 && p.Category == "Meat/Poultry");

            ////query syntax
            //   result= from p in ProductsList
            //    where p.Category== "Meat/Poultry" && p.UnitsInStock > 0 
            //    select p;
            //PrintCollection(result);

            #endregion

            #region Get Elements Out Of Stock In First 10 Elements
            //indexed where valid only in fluent syntax 
            // used to have an access to to index of elements of sequence

            //var result =ProductsList.Where((p,i)=> p.UnitsInStock==0 && i<10 );
            //PrintCollection(result);
            #endregion


            #endregion

            #region Transformation-Operators
            #region Select Product Name
            //fluent syntax
            // var result= ProductsList.Select(p => p.ProductName);
            //query syntax
            //result = from p in ProductsList
            //         select p.ProductName;
            //PrintCollection(result);

            #endregion
            #region Select Customer Name
            //fluent syntax
            //var result= CustomersList.Select(c => c.CustomerName);
            // //Query syntax
            // result = from c in CustomersList
            //          select c.CustomerName;
            // PrintCollection(result);

            #endregion

            #region Select Product Id and Product Name 

            ////fluent syntax
            //var result=ProductsList.Select(p => new { p.ProductID, p.ProductName });
            ////query syntax
            //result = from p in ProductsList
            //         select new { p.ProductID, p.ProductName };
            //PrintCollection(result);

            #endregion

            #region Select Customer Orders

            //var result = from c in CustomersList
            //              select c.Orders; // this will not retrieve data it will execute ToString() of Order

            //Fluent syntax
            //var result = CustomersList.SelectMany(c => c.Orders); //it will print all orders of all customers
            ////query syntax
            //result = from c in CustomersList
            //         from o in c.Orders
            //         select o;

            //PrintCollection(result);
            #endregion

            #region Select Product In Stock And Apply Discount 10 % On Its Price
            //fluent Syntax
           //var result= ProductsList.Where(p => p.UnitsInStock > 0)
           //     .Select(p =>
           //     new {p.ProductID,p.UnitPrice, PriceAfterDiscount = (p.UnitPrice - p.UnitPrice * .1M) });
           
           // //query syntax
           // result = from p in ProductsList
           //          where p.UnitsInStock > 0
           //          select new
           //          {
           //              p.ProductID,
           //              p.UnitPrice,
           //              PriceAfterDiscount = (p.UnitPrice - p.UnitPrice * .1M)
           //          };
           // PrintCollection(result);
        
            #endregion
            #endregion
        }

    }
}
