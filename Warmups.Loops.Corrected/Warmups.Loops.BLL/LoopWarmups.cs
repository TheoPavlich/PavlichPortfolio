using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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


        public string FrontTimes(string str, int n)
        {
            string result = "";
            string sub = str.Substring(0, 3);

            for (int j = 0; j < n; j++)
            {
                result += sub;
            }

            return result;
        }

        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                string sub = str.Substring(i, 2);
                if (sub == "xx")
                {
                    count++;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == "x")
                {
                    if (str.Substring(i + 1, 1) == "x")
                    {
                        return true;
                    }
                    return false;

                }

            }
            return false;
        }

        public string EveryOther(string str)
        {
            string half = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i%2 == 0)
                {
                    half += str.Substring(i, 1);
                }

            }
            return half;
        }

        public string StringSplosion(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += str.Substring(0, i+1);
            }
            return result;
        }

        public int CountLast2(string str)
        {
            string last = str.Substring(str.Length - 2, 2);
            int count = 0;
            for (int i = 0; i < str.Length-2; i++)
            {
                string test = str.Substring(i, 2);
                if (last == test)
                {
                    count++;
                }
            }
            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] nums)
        {
            bool nine = false;
            int four = 4;
            if (nums.Length < 4)
            {
                four = nums.Length;
            }

            for (int i = 0; i < four; i++)
            {
                if (nums[i] == 9)
                {
                    nine = true;
                }
            }
            return nine;
        }

        public bool Array123(int[] nums)
        {
            bool test = false;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i]==1)
                {
                    if (nums[i + 1] == 2)
                    {
                        if (nums[i + 2] == 3)
                        {
                            test = true;
                        }
                    }
                    
                }
            }

            return test;
        }

        public int SubStringMatch(string strA, string strB)
        {
            int count = 0;
            int strLength = 0;
            if (strA.Length > strB.Length)
            {
                strLength = strB.Length - 1;
            }
            else
            {
                strLength = strA.Length - 1;
            }
            for (int i = 0; i < strLength; i++)
            {
                string subA = strA.Substring(i, 2);
                string subB = strB.Substring(i, 2);
                if (subA == subB)
                {
                    count++;
                }

            }
            return count;
        }

        public string StringX(string str)
        {
            string result = str.Substring(0,1);
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str.Substring(i,1) != "x")
                {
                    result += str.Substring(i,1);
                }
            }
            result += str.Substring(str.Length-1, 1);
            return result;
        }

        public string AltPairs(string str)
        {
            string result = "";
         
            if (str.Length%2 == 0)
            {
                for (int i = 0; i < str.Length-1; i += 4)
                {
                    result += str.Substring(i, 2);
                }
            }
            else
            {
                for (int i = 0; i < str.Length - 3; i += 4)
                {
                    result += str.Substring(i, 2);
                }
                result += str.Substring(str.Length-1, 1);
            }

            return result;
        }

        public string DoNotYak(string str)
        {
            
          //  yakpak
          string bad = "yak";
          string result = "";
          int strL = str.Length-1;
          for (int i = 0; i < strL; i+=3)
          {
              if (str.Length > i + 2)
              {
                  if (str.Substring(i, 3) != bad)
                  {
                      result += str.Substring(i, 1);
                      if (str.Substring(i + 1, 1) != "y")
                      {
                          result += str.Substring(i + 1, 1);
                          if (str.Substring(i + 2, 1) != "y")
                          {
                              result += str.Substring(i + 2, 1);
                          }

                      }

                  }

              }
              else
              {
                  for (int j = i; j <= strL; j++)
                      result += str.Substring(j, 1);
              }
          } 
          return result;
        
            
        }

        public int Array667(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i] == 6)
                {
                    if (nums[i + 1] == 6 || nums[i + 1] == 7)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool NoTriples(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    if (nums[i + 1] == nums[i + 2])
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }

        public bool Pattern51(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int five = nums[i] + 5;
                int one = nums[i] - 1;
                if (nums[i + 1] == five && nums[i + 2] == one)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
