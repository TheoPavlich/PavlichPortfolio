using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Conditionals.BLL
{
    public class ConditionalWarmups
    {
        public bool MischeviousChildren(bool kidA, bool kidB)
        {
            if (kidA == kidB)
            {
                return true;
            }
            return false;
        }
       
        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (!isWeekday || isVacation)
                return true;
            return false;

        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;

            if (a != b)
                return sum;
            return (2 * sum);

        }

        public int Diff21(int n)
        {
            int diff = Math.Abs(21 - n);
            if (n > 21)
                return diff * 2;
            return diff;
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (!isTalking)
                return false;
            if (hour < 7 || hour > 20)
                return true;
            return false;
        }

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10 || a + b == 10)
                return true;
            return false;
        }

        public bool NearHundred(int n)
        {
            int oneHun = Math.Abs(100 - n);
            int twoHun = Math.Abs(200 - n);
            if (oneHun <= 10 || twoHun <= 10)
                return true;
            return false;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (!negative)
            {
                if ((a < 0 && b < 0) || (a >= 0 && b >= 0))
                    return false;
                return true;
            }

            if (a >= 0 && b >= 0)
                return false;
            return true;

        }

        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return "not " + s;
            }
            if (s.Substring(0, 3) == "not")
            {
                return s;
            }
            return "not " + s;
        }

        public string MissingChar(string s, int n)
        {
            return s.Remove(n, 1);
        }

        public string FrontBack(string s)
        {
            if (s.Length < 2)
            {
                return s;
            }
            if (s.Length == 2)
            {
                return s.Substring(1, 1) + s.Substring(0, 1);
            }
            return s.Substring(s.Length - 1, 1) + s.Substring(1, s.Length - 2) + s.Substring(0, 1);
        }

        public string Front3(string s)
        {
            if (s.Length < 3)
            {
                return s + s + s;
            }
            return s.Substring(0, 3) + s.Substring(0, 3) + s.Substring(0, 3);
        }

        public string BackAround(string s)
        {
            return s.Substring(s.Length - 1, 1) + s + s.Substring(s.Length - 1, 1);
        }

        public bool Multiple3Or5(int n)
        {
            if (n%3 == 0 || n%5 == 0)
            {
                return true;
            }
            return false;
        }

        public bool StartHi(string s)
        {
            if (s.Length < 2)
            {
                return false;
            }
            if (s == "hi")
            {
                return true;
            }
            if (s.Substring(0, 3) == "hi ")
            {
                return true;
            }
            return false;
        }

        public bool IcyHot(int a, int b)
        {
            if (a > 100 && b < 0 || b > 100 && a < 0)
            {
                return true;
            }
            return false;
        }

        public bool Between10And20(int a, int b)
        {
            if (a < 21 && a > 9 || b < 21 && a > 9)
            {
                return true;
            }
            return false;
        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a > 12 && a < 20 || b > 12 && b < 20 || c > 12 && c < 20)
            {
                return true;
            }
            return false;
        }

        public bool SoAlone(int a, int b)
        {
            if (a > 12 && a < 20 && b > 12 && b < 20 )
            {
                return false;
            }
            return true;
        }

        public string RemoveDel(string s)
        {
            if (s.Length < 3)
                return s;
            if (s == "del")
                return "";
            for (int i = 1; i < s.Length-1; i++)
            {
                if (s.Substring(i, 1) == "d")
                {
                    if (s.Substring(i + 1, 1) == "e")
                    {
                        if (s.Substring(i + 2, 1) == "l")
                        {
                            return s.Substring(0, i) + s.Substring(i + 3);
                        }
                    }
                }
             }
            return s;
        }

        public bool IxStart(string s)
        {
            if (s.Substring(1, 2) == "ix")
            {
                return true;
            }
            return false;
        }

        public string StartOz(string s)
        {
            string r = "";
            if (s.Substring(0, 1) == "o")
            {
                r += s.Substring(0, 1);
            }
            if (s.Substring(1, 1) == "z")
            {
                r += s.Substring(1, 1);
            }
            return r;
        }

        public int Max(int a, int b, int c)
        {
            int max = a;
            if (max < b)
            {
                max = b;
            }
            if (max < c)
            {
                max = c;
            }
            return max;
        }

        public int Closer(int a, int b)
        {
            int aDiff = Math.Abs(10 - a);
            int bDiff = Math.Abs(10 - b);
            if (aDiff < bDiff)
            {
                return a;
            }
            if (aDiff == bDiff)
            {
                return 0;
            }
            return b;
        }

        public bool GotE(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1) == "e")
                {
                    count++;
                }
            }
            if (count < 4 && count > 0)
            {
                return true;
            }
            return false;
        }

        public string EndUp(string s)
        {
            if (s.Length < 4)
            {
                return s.ToUpper();
            }
            return s.Substring(0, s.Length - 3) + s.Substring(s.Length - 3).ToUpper();
        }

        public string EveryNth(string s, int n)
        {
            string r = "";
            for (int i = 0; i < s.Length; i += n)
            {
                r += s.Substring(i, 1);
            }
            return r;
        }
    }
}
