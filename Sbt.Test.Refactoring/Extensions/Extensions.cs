using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Extensions
{
    public static class Extensions
    {

        public static Orientation GetNext(this Orientation src) 
        {
            Orientation[] arr = (Orientation[])Enum.GetValues(typeof(Orientation));
            int j = Array.IndexOf(arr, src) + 1;
            return (arr.Length == j) ? arr[0] : arr[j];
        }
    }
}
