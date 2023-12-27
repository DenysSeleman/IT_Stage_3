using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Stage_3
{
    class bdTypeStringCharInvl : bdType
    {
        char S1, S2;
        public bdTypeStringCharInvl(char s1, char s2)
        {
            S1 = s1;
            S2 = s2;
        }
        public override bool Validation(string value)
        {
            for (int i = 0; i < value.Length; i++)
                if (value[i] < S1 || value[i] > S2)
                    return false;
            return true;
        }
    }
}