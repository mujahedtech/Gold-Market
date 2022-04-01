using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market.DataBase
{
    class SQLite
    {

        public SQLiteAsyncConnection GetConnection()
        {
            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //var path = Path.Combine(documentsPath, "MySQLite.db3");


            return new SQLiteAsyncConnection(StoriedParameter.DataBaseName);
        }



    }
}
