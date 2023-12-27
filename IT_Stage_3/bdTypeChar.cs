using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    class bdTypeChar : bdType
    {
        public override bool Validation(string value)
        {
            char buf;
            if (char.TryParse(value, out buf)) return true;
            return false;
        }
    }
}