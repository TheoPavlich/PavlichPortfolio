using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Loops.BLL
{
    public class LoopWarmups
    {
        public string StringTimes(string str, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }
    }
}