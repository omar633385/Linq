namespace Linq01Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Var vs dynamic
            //string name = "ahmed";
            #region Var

            //var name = "ahmed";
            ////compiler can detect variable data type based on its inital value during Compliation Time
            //var name02; //Invalid => should be inilized but can't be initlized with null

            ////c# strongly type  

            /// var is used only as local variable not used in class or struct as property or field
            /// function can't return var or take parameter of type var

            #endregion
            #region dynamic
            //dynamic name; //valid =>can also be initliazed 
            ////can be initliazed with null
            //name = "hamada";
            //name = 50;
            //like var in JS
            //CLR detects datatype based on its last assigned value at RunTime 

            #endregion

            ///Most Recommended is var => compiler can detect variable data type at Compliation Time
            ///unlike dynamic => CLR detects datatype at  RunTime (unsafe) => May throw exception

            #endregion

            #region ExtensionMethods
            //123
            //321
            //int x = 123;
            //Console.WriteLine($"Before Reversing => x = {x}");
            // int y=IntExtenstions.reverse(x);
            // y=x.reverse(); //int doesn't have function to reverse [Implementation of class int is readonly]
            //             //solution is Extension Method =>  makes int  gain more capabilites

            //Console.WriteLine($"After Reversing => x = {y}");

            #endregion

            #region Anonymous Type
            //create object from class but used only once or twice => No need to create class
            // Employee employee =new Employee() { Id=10,Name="Ahmed",Salary=5000};

            // var employee2 = new { Id = 10, Name = "Ahmed", Salary = 5000 }; // Anonymous Type

            // //we can use dynamic but may throw exception if you want to access property not in the type

            // Console.WriteLine(employee2.GetType().Name); // <>f__AnonymousType0`3
            // //Compiler will create class with these properties  its name will be => AnonymousType0`3
            // // AnonymousType0 means that first AnonymousType compiler has created
            // // `3 means that has 3 properties

            // //object from AnonymousType is immutable => can't be changed

            // //employee2.Id = 20; // invalid

            // employee2 = new { Id = 10, Name = "Ahmed", Salary = 5000 };
            // // if we want to change object data
            // employee2 = new { Id = 20, employee2.Name, employee2.Salary };

            // employee2 = employee2 with { Id = 20 };// c# 10 feature [syntax sugar]
            // Console.WriteLine(employee2.GetType().Name);
            // // The AnonymousType still the same as long as
            //     //1. Same Property name [Case Sensetive]
            //    //2. same Property order

            //var employee02 = new { Id = 50, Name = "hamada", Salary = 8000 };
            //var employee03 = new { Id = 50, name = "hamada", Salary = 8000 };
            //var employee04 = new { Id = 50, Salary = 8000, Name = "hamada" };


            #endregion

            #region LINQ
            //Stands For Language Integrated Query
            //Linq has 13 category of DQL in SQL integrated in +40 Extension Methods [for built-in interface IEnumerable] these methods are in Enumerable class
            //LINQ allow us to write queries against data [Stored in sequence] regradless database provider

            //Sequence =>object from class impelments built in interface IEnumberable 
            //sequence has two types:
            //1.local[static => L2O,xml=>L2xml]
            //2. remote [comes from db =>L2 ef] 


            // Ef [ORM] translate Linq to [db queries] based on database provider   ==> ex: c# to sql


            //List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10}; // Local sequence

            ////List<int> OddNumbers= numbers.Where(x=>x%2==1).ToList();
            //var OddNumbers= numbers.Where(x => x % 2 == 1);
            //foreach (var item in OddNumbers)
            //{
            //    Console.WriteLine(item);
            //}
            ////foreach has GetEnumerator(),GetNext() => they are in IEnumerable
            //// so if there is class implements or inherits IEnumerable => foreach can be used

            #endregion

            #region LINQ Syntax
            //List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10}; // Local sequence


            #region Fluent Syntax
            //Fluent Syntax has 2 ways


            #region 1.static method
            //var OddNumbers = Enumerable.Where(numbers, x => x % 2 == 1);
            //foreach (var item in OddNumbers)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion


            #region 2.Using ExtensionMethods

            //OddNumbers = numbers.Where(x=> x % 2 == 1); //Most Recommended
            #endregion

            #endregion

            #region Query Syntax[QueryExpression]

            //like sqlserver style based on Sql Execution Order 
            //OddNumbers= from n in numbers
            //            where n%2==1
            //            select n;


            //query must end with select or group by
            #endregion
            #endregion

            #region Linq Execution way

            //Linq has 2 ways for Execution 
            //Immediate Execution [element,aggergate,casting] ,rest are Deffered Execution
            
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 
            
            var OddNumbers = numbers.Where(x => x % 2 == 1); // where is deffered 
            numbers.AddRange(new int[] {11,12,13,14,15});
            foreach (var item in OddNumbers)
            {
                Console.WriteLine(item);
            }


            #endregion


        }
    }
}
