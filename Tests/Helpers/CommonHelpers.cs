using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers
{
    internal class CommonHelpers
    {
        internal static DateTime RandomDay()
        {
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(1999, 12, 31);
            Random gen = new Random();

            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
