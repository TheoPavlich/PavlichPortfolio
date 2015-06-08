using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Arrays.BLL
{
    public class WarmupArray
    {
        public bool FirstLast6(int[] num)
        {
            if (num[0] == 6)
            {
                return true;
            }
            if (num[num.Length - 1] == 6)
            {
                 return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] num)
        {
            if (num[0] == num[num.Length - 1])
            {
                return true;
            }
            return false;
        }

        public int[] MakePi(int n)
        {
            string piDigits = (Math.PI).ToString().Remove(1,1);
            int[] pi = new int[n];
            for(int i =0; i<n; i++)
            {
                int dig = Int32.Parse(piDigits.Substring(i, 1));
                pi[i] = dig;
            }
            return pi;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            int lastA = a[a.Length - 1];
            int lastB = b[b.Length - 1];
            if (lastA == lastB)
                return true;
            return false;
        }

        public int Sum(int[] a)
        {
            int sum=0;
            foreach (int c in a)
            {
                sum += c;
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] a)
        {
            int[]b= new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (i == a.Length - 1)
                {
                    b[i] = a[0];
                }
                else
                {
                    b[i] = a[i + 1];
                }
            }
            return b;
        }

        public int[] Reverse(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[a.Length-(i+1)];
                
            }
            return b;
        }

        public int[] HigherWins(int[] a)
        {
            int[] b = new int[a.Length];
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (max < a[i])
                {
                    max = a[i];
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = max;

            }
            return b;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] c = new int[2];
            c[0] = a[a.Length/2];
            c[1] = b[b.Length / 2];
            return c;
        }

        public bool HasEven(int[] num)
        {
            foreach (int a in num)
            {
                if (a%2 == 0)
                    return true;
            }
            return false;
        }

        public int[] KeepLast(int[] a)
        {
            int[]b = new int[2*a.Length];
            b[b.Length - 1] = a[a.Length - 1];
            return b;
        }

        public bool Double23(int[] a)
        {
            int two = 0;
            int three = 0;
            foreach (int b in a)
            {
                if(b==2)
                {
                    two++;
                }
                if (b == 3)
                {
                    three++;
                }
            }
            if (two == 2 || three == 2)
            {
                    return true;
            }
            return false;

        }

        public int[] Fix23(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] == 2 && a[i + 1] == 3)
                {
                    a[i + 1] = 0;
                }
            }
            return a;
        }

        public bool Unlucky1(int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i] == 1 && a[i + 1] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] c = new int[2];
            for (int i = 0; i < 2; i++)
            {
                if (a.Length == 0)
                {
                    c[i] = b[i];
                }
                else if (a.Length == 1 && i == 1)
                {
                    c[i] = b[i-1];
                }
                else
                {
                    c[i] = a[i];
                }
            }
            return c;
        }
    }
}
