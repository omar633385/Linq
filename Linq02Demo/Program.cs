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

            #region Indexed Select
            //overload for select that has another parameter index enables us to control index of elements 
            //valid only in fluent syntax

            //var result = ProductsList.Select((p, i) => new { index=i, p.ProductName });
            //PrintCollection(result);

            #region Select many
            //var CustomersOrders= CustomersList.SelectMany(c => c.Orders); // retireve all orders for all customers
            // PrintCollection(CustomersOrders);
            #endregion
            #endregion
            #endregion

            #region Ordering-Operators

            #region Get Products Ordered By Price Asc

            //fluent syntax
            //var result= ProductsList.OrderBy(p=>p.UnitPrice);

            //query syntax
            //result= from p in ProductsList
            //            orderby p.UnitPrice
            //            select p;
            //PrintCollection(result);

            #endregion

            #region Get Products Ordered By Price Desc
            //fluent syntax
            //var result = ProductsList.OrderByDescending(p => p.UnitPrice);

            //query syntax
            // result= from p in ProductsList
            //            orderby p.UnitPrice descending
            //            select p;
            //PrintCollection(result);

            #endregion

            #region Get Products Ordered By Price Asc and Number Of Items In Stock
            //fluent syntax
            //var result = ProductsList.OrderBy(p => p.UnitPrice).ThenBy(p=>p.UnitsInStock);

            //query syntax
            //result= from p in ProductsList
            //        orderby p.UnitPrice,p.UnitsInStock
            //        select p;
            #endregion

            #region Reverse method example
            //var result = ProductsList.Where(p => p.UnitsInStock == 0).Reverse();
            //PrintCollection(result);

            #endregion

            #endregion

            #region Element-operators valid only in fluent syntax[immediate Execution]

            #region First-Last
            //var element=ProductsList.First(); 
            //// there is overload that takes predicate

            // element=ProductsList.Last();// there is overload that takes predicate




            //Console.WriteLine(element); 
            #endregion



            //First,Last will throw exception if the collection is null or empty
            //so that FirstOrDefault,LastOrDefault are used widely

            #region First,LastOrDefault
            //ProductsList = new List<Product>();
            //
            //var DefaultElement = ProductsList.FirstOrDefault(); // there is overload that takes predicate
            //
            //DefaultElement = ProductsList.FirstOrDefault(new Product() { ProductName = "Product No Found" });
            //DefaultElement = ProductsList.LastOrDefault(new Product() { ProductName = "Product No Found" });
            //
            //DefaultElement = ProductsList.FirstOrDefault(p => p.UnitsInStock == 0, new Product() { ProductName = "Product No Found" });
            //DefaultElement = ProductsList.LastOrDefault(p => p.UnitsInStock == 0, new Product() { ProductName = "Product No Found" });
            //
            //
            //Console.WriteLine(DefaultElement?.ProductName);// will throw exception unless you add null propagation operator

            #endregion

            #region ElementAt-ElementAtOrDefault
            //var elementAt=ProductsList.ElementAt(0); //takes index as input
            //will throw exception if element is null or index not found
            //elementAt=ProductsList.ElementAtOrDefault(1);
            //Console.WriteLine(elementAt);

            #endregion


            #region Single-SingleOrDefault
            //var element=ProductsList.Single(); //will throw exception if there is more than one element or Sequence is null
            //there is overload for Single() that takes predicate

            //var element = ProductsList.Single(p => p.ProductID == 77);
            ////element =ProductsList.SingleOrDefault(); //will throw exception if there is more than one element
            //Console.WriteLine(element);


            #endregion
            #endregion

            #region  Aggregate-operators  - Immediate Execution

            #region Count
            //var result = ProductsList.Count(p => p.UnitsInStock == 0);
            //result = ProductsList.Where(p => p.UnitsInStock == 0).Count();
            ////both are equilvant

            #endregion

            #region Max-Min
            //var result=ProductsList.Max();//as Product class implements Icomparable for UnitPrice => it will retrieve product that has Maximum UnitPrice

            //result=ProductsList.OrderByDescending(p=>p.UnitPrice).FirstOrDefault();
            ////in .net 6 they made MaxBy operator that was equilvant to the prevoius line instead of implemen
            //result = ProductsList.MaxBy(p=>p.ProductID);//it will be more dynamic like Order,OrderBy

            ////the same thing for min

            //Console.WriteLine(result);
            #endregion

            #region Sum-Average
            //var sum=ProductsList.Sum(p=>p.UnitPrice);//element to iterate should be numeric
            //Console.WriteLine(sum);
            //var avg = ProductsList.Average(p => p.UnitPrice);//element to iterate should be numeric
            //Console.WriteLine(avg);
            #endregion

            #region Aggeregate 
            //var names = new string[] { "omar","ali","ahmed" };
            //names.Aggregate((n1,n2)=>n1+n2);
            //// 1st parameter here is named as seeddata the first thing to start
            //// then 2nd parameter  accumlates (takes data) to 1st parameter then
            //// 2nd parameter moves to next element

            //foreach (var item in names)
            //{
            //    Console.Write(item+" " );
            //}

            #endregion
            #endregion

            #region Casting [Conversion] Operators - Immediate Execution

            // List<Product> result= ProductsList.Where(p=>p.UnitsInStock==0).ToList();
            //Product[] arr= ProductsList.Where(p=>p.UnitsInStock==0).ToArray();
            // Dictionary<long,Product> dic= ProductsList.Where(p => p.UnitsInStock == 0).ToDictionary(p=>p.ProductID);
            // Dictionary<long,string> dic02= ProductsList.Where(p => p.UnitsInStock == 0).ToDictionary(p=>p.ProductID,p=>p.ProductName);
            // HashSet<Product> hash= ProductsList.Where(p => p.UnitsInStock == 0).ToHashSet();
            //PrintCollection(hash);


            // //as Product is class so it will compare References 
            // //if data of two objects have the same data they won't be equivalent
            // //so override GetHashCode,Equals to compare values

            //ArrayList array = new ArrayList()
            //{
            //    "omar","ali",1,2,3
            //};
            //var result=array.OfType<int>();// filters data based on specified type and another element will be ignored from the list/collection
            //PrintCollection(result);
            #endregion

            #region     
            //generates sequence
            // don't have input sequence but have output sequence [Fluent Syntax only] =>By Enumerable class as static function

            var result = Enumerable.Range(0, 100); //0 ..99
            result = Enumerable.Repeat(0, 10); //will repeat 0 for 10 times
            result=Enumerable.Empty<int>();//generic method of type that sequence will be
            PrintCollection(result);
            #endregion
        }

    }
}
