using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    class bdTypeInteger : bdType
    {
        public override bool Validation(string value)
        {
            int buf;
            if (int.TryParse(value, out buf)) return true;
            return false;
        }
    }
}