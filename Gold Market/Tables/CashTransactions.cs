using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.Tables
{
    class CashTransactions
    {
        [PrimaryKey, AutoIncrement]
        public Guid TransID { get; set; }
        public string AccountName { get; set; }
        public string username { get; set; }

        public decimal TotalCash { get; set; }
        public decimal TotalCheque { get; set; }
        public decimal totalNetCash { get; set; }
        public DateTime EnterDate { get; set; }

        public string Notes { get; set; }



    }
}
