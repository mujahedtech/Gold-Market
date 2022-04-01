using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market
{
   public class Validations
    {
        public static bool IsNumeric(string input)
        {
            decimal test = 0;
            return decimal.TryParse(input, out test);
        }


        public static bool IsDate(string input)
        {
            DateTime test;
            return DateTime.TryParse(input, out test);
        }


        public static bool IsDouble(string input)
        {
            double test;
            return double.TryParse(input, out test);
        }

        public static bool Isdecimal(string input)
        {
            decimal test;
            return decimal.TryParse(input, out test);
        }
    }
}
