using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.Tables
{
   public class Karats
    {

        [PrimaryKey, AutoIncrement]
        public Guid KaratID { get; set; }
        public string KaratName { get; set; }
        public decimal KaratValue { get; set; }

        public string Notes { get; set; }

    }
}
