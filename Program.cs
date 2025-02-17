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
            dynamic name; //valid =>can also be initliazed 
            //can be initliazed with null
            name = "hamada";
            name = 50;
            //like var in JS
            //CLR detects datatype based on its last assigned value at RunTime 

            #endregion

            ///Most Recommended is var => compiler can detect variable data type at Compliation Time
            ///unlike dynamic => CLR detects datatype at  RunTime (unsafe) => May throw exception

            #endregion
        }
    }
}
