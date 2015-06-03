using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Strings.BLL
{
    public class StringWarmups
    {
        public string SayHi(string name)
        {
            string hello = "Hello " + name + "!";
            return hello;
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
            //return result;
        }

        public string MakeTags(string a, string b)
        {
            return "<" + a + ">" + b + "</" + a + ">";
        }

        public string InsertWord(string a, string b)
        {
            return a.Substring(0, 2) + b + a.Substring(2, 2);
        }

        public string MultipleEndings(string a)
        {
            return (a.Substring(a.Length - 2))+(a.Substring(a.Length - 2)) + (a.Substring(a.Length - 2));

        }

        public string FirstHalf(string a)
        {
            return a.Substring(0, a.Length/2);
        }

        public string TrimOne(string a)
        {
            return a.Substring(1, a.Length-2);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            return a + b + a;
        }

        public string RotateLeft2(string a)
        {
            if (a.Length > 2)
            {
                return a.Substring(2, a.Length - 2) + a.Substring(0, 2);
            }
            return a;
        }

        public string RotateRight2(string a)
        {
            if (a.Length > 2)
            {
                return a.Substring(a.Length-2,2) + a.Substring(0, a.Length-2);
            }
            return a;
        }

        public string TakeOne(string a, bool front)
        {
            if (front)
            {
                return a.Substring(0, 1);
            }
            return a.Substring(a.Length - 1, 1);
        }

        public string MiddleTwo(string a)
        {
            int mid = (a.Length/2) - 1;
            return a.Substring(mid, 2);
        }

        public bool EndsWithLy(string a)
        {
            string ly = "ly";
            if (a.Length < 2)
            {
                return false;
            }
            int lastTwo = a.Length - 2;
            if (a.Substring(lastTwo, 2) == ly)
            {
                return true;
            }
            return false;
           
        }

        public string FrontAndBack(string a, int n)
        {
            return a.Substring(0, n) + a.Substring(a.Length-(n));
         }

        public string TakeTwoFromPosition(string a, int n)
        {
            if (a.Length - 1 <= n)
            {
                return a.Substring(0,2);
            }
            return a.Substring(n, 2);

        }

        public bool HasBad(string a)
        {
            if (a.Length < 3)
            {
                return false;
            }
            if (a.Substring(0, 3)=="bad")
            {
                 return true;
            }
            if (a.Length < 4)
            {
                return false;
            }
            if (a.Substring(1, 3) == "bad")
            {
                return true;
            }
            return false;

        }

        public string AtFirst(string a)
        {
            if (a.Length > 1)
            {
                return a.Substring(0, 2);
            }
            if(a.Length == 1)
            {
                return a + "@";
             }
            return "@@";
        }

        public string LastChars(string a, string b)
        {
            if (a.Length > 0 )
            {
                if (b.Length > 0)
                {
                    return a.Substring(0, 1) + b.Substring(b.Length - 1, 1);
                }
                return a.Substring(0, 1) + "@";
            }
            if (b.Length>0)
            {
                return "@" + b.Substring(b.Length - 1, 1);
            }
            return "@@";
        }

        public string ConCat(string a, string b)
        {
            if (a.Length>0 && b.Length>0 && a.Substring(a.Length - 1, 1) == b.Substring(0, 1))
             {
                    return a + b.Substring(1);
             }
            return a + b;
        }

        public string SwapLast(string a)
        {
            if (a.Length < 2)
            {
                return a;
            }
            return a.Substring(0, a.Length - 2) + a.Substring(a.Length - 1, 1) + a.Substring(a.Length - 2, 1);
        }

        public bool FrontAgain(string a)
        {
            if (a.Length <= 2)
            {
                return true;
            }
            if (a.Substring(0, 2) == a.Substring(a.Length - 2, 2))
            {
                return true;
            }
            return false;

        }

        public string MinCat(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return a.Substring(a.Length - b.Length, b.Length) + b;
            }
            if (b.Length > a.Length)
            {
                return a+ b.Substring(b.Length - a.Length, a.Length);
            }
            return a + b;
        }

        public string TweakFront(string a)
        {
            if (a.StartsWith("a"))
            {
                if (a.Substring(1, 1) == "b")
                {
                    return a;
                }
                return "a" + a.Substring(2);
            }
            if (a.Substring(1, 1) == "b")
            {
                return a.Substring(0, 1) + a.Substring(2);
            }
            return a.Substring(2);
        }

        public string StripX(string a)
        {
            if (a.StartsWith("x"))
            {
                if (a.EndsWith("x"))
                {
                    return a.Substring(1, a.Length - 2);
                }

                return a.Substring(1);
            }
            if (a.EndsWith("x"))
            {
                return a.Substring(0, a.Length - 1);
            }
            return a;
        }
    }
}
