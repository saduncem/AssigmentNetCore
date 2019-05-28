using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletAssingment.Extensions
{
    public static class DateExtensions
    {
        public static string ObiletDateFormat(this DateTime date)
        {
           return date.ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
}
