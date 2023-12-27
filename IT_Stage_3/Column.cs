using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    public class Column
    {
        public string cName;
        public bdType cType;
        public string typeName;

        public Column(string cname, string ctype)
        {
            cName = cname;
            typeName = ctype;

            switch (ctype)
            {
                case "Integer":
                    cType = new bdTypeInteger();
                    break;
                case "Real":
                    cType = new bdTypeReal();
                    break;
                case "Char":
                    cType = new bdTypeChar();
                    break;
                case "String":
                    cType = new bdTypeString();
                    break;
                default:
                    cType = new bdTypeString();
                    break;
            }
        }

        public Column(string cname, string ctype, char s1, char s2)
        {
            cName = cname;
            typeName = ctype;

            if (ctype == "CharInvl")
                cType = new bdTypeCharInvl(s1, s2);
            else
                cType = new bdTypeStringCharInvl(s1, s2);
        }
    }
}