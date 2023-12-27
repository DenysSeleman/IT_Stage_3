using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IT_Stage_3
{
    class DataBase
    {
        public string dbName;
        public List<Table> dbTablesList;

        public DataBase(string dbname)
        {
            dbName = dbname;
            dbTablesList = new List<Table>();
        }
    }
}