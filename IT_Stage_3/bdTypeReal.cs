using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    class bdTypeReal : bdType
    {
        public override bool Validation(string value)
        {
            double buf;
            if (double.TryParse(value, out buf)) return true;
            return false;
        }
    }
}