using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    class bdTypeCharInvl : bdType
    {
        char S1, S2;
        public bdTypeCharInvl(char s1, char s2)
        {
            S1 = s1;
            S2 = s2;
        }
        public override bool Validation(string value)
        {
            char buf;
            if (!char.TryParse(value, out buf)) return false;
            if (buf < S1 || buf > S2) return false;
            return true;
        }
    }
}