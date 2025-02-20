using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq02Assignment
{
    internal class CustomComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(y, x);
        }
    }
}
