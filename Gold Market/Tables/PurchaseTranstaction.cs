using Gold_Market.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.Tables
{
    class PurchaseTranstaction
    {

        [PrimaryKey, AutoIncrement]
        public Guid TransID { get; set; }
        public string VendorName { get; set; }
        public string username { get; set; }

        public decimal totalCost { get; set; }
        public decimal totalPaidGold { get; set; }
        public decimal totalNetCost { get; set; }



      

        public DateTime EnterDate { get; set; }

    }
}
