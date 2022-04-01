using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.Tables
{
   public class Vendors
    {

        [PrimaryKey, AutoIncrement]
        public Guid VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorNumber { get; set; }

        public string Notes { get; set; }

    }
}
