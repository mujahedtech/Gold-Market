using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.Tables
{
    class Debits
    {

        [PrimaryKey, AutoIncrement]
        public Guid TransID { get; set; }
        public string AccountName { get; set; }
        public decimal DebitValue { get; set; }
        public string Notes { get; set; }
        public DateTime EnterDate { get; set; }

    }
}
