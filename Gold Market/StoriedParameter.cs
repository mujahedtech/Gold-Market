using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market
{
   public class StoriedParameter
    {
        public static string DataBaseName { get; set; } = "MujahedTech.db3";
        public static string LicenseName { get; set; } = "AboAymanHawari";

        public static string Lang { get; set; } = "Ar";




        static SQLiteAsyncConnection connection;
        public static SQLiteAsyncConnection _connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }

    }


}
