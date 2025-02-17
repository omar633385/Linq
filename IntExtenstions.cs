using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq01Demo
{
    public static class IntExtenstions
    {
        // Extenstion Method should be static method in static class
        
        public static int reverse(this int number)
        {
            int ReversedNumber=0 ,remainder;
            while (number != 0) {
            remainder = number % 10;
            ReversedNumber= ReversedNumber*10+ remainder;
            number/=10; 
            }
            return ReversedNumber;
        }
    }
}
