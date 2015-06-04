using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Logic.BLL
{
    public class LogicWarmups
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars < 40)
            {
                return false;
            }
            if (cigars > 60 && !isWeekend)
            {
                return false;
            }
            return true;

        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle < 3 || dateStyle < 3)
            {
                return 0;
            }
            if (yourStyle > 7 || dateStyle > 7)
            {
                return 2;
            }

            return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp < 60)
            {
                return false;
            }
            if ((temp > 90 && !isSummer) || (temp > 100 && isSummer))
            {
                return false;
            }
            return true;

        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday)
                speed -= 5;

            if (speed <= 60)
                return 0;

            if (speed >= 61 && speed <= 80)
                return 1;

            return 2;
        }

        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum <= 19)
                return 20;
            return sum;
        }

        public string AlarmClock(int day, bool vacation)
        {
            if (day != 0 && day != 6)
            {
                if (vacation)
                {
                    return "10:00";
                }
                
                    return "7:00";
            }

            if (vacation)
                return "off";
            return "10:00";



        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6 || a + b == 6 || (a - b == 6 || b - a == 6))
                return true;
            return false;
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10)
                return true;
            if (outsideMode)
                return true;
            return false;

        }

        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || n % 11 == 1)
                return true;
            return false;
         }

        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
                return true;
            return false;


        }

        public bool Mod35(int n)
        {
            if ((n % 3 == 0 && n % 5 != 0) || (n % 3 != 0 && n % 5 == 0))
                return true;
            return false;

        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep)
                return false;
            if (!isMorning || isMom)
                return true;
            return false;

        }

        public bool TwoIsOne(int a, int b, int c)
        {
            if ((a + b == c) || (b + c == a) || (a + c == b))
                return true;
            return false;

        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (b < c && (bOk || a < b))
                return true;
            return false;
        }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a > b || b > c)
                return false;
            if ((a < b || (a <= b && equalOk)) && (b < c || (b <= c && equalOk)))
                return true;
            return false;
        }

        public bool LastDigit(int a, int b, int c)
        {
            if ((a - b) % 10 == 0 || (b - c) % 10 == 0 || (a - c) % 10 == 0)
                return true;
            return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;
            if (die1 != die2 || !noDoubles)
                return sum;
            if (die1 != 6)
            {
                sum++;
                return sum;
            }
            return 7;
        }
    }

}
