using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    public class Table
    {
        public string tName;
        public List<Column> tColumnsList;
        public List<Row> tRowsList;

        public Table(string tname)
        {
            tName = tname;
            tColumnsList = new List<Column>();
            tRowsList = new List<Row>();
        }
    }
}