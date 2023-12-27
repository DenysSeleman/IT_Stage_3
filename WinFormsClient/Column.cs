using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    public class Column
    {
        public string cName;
        public string typeName;

        public Column(string cname, string ctype)
        {
            cName = cname;
            typeName = ctype;
        }

        public Column(string cname, string ctype, char s1, char s2)
        {
            cName = cname;
            typeName = ctype;

        }
    }
}
