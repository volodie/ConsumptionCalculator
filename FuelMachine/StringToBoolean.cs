using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelMachine
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string value)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }

            return false;
        }
    }
}
