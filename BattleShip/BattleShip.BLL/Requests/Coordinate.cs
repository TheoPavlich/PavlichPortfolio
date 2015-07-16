using System;

namespace BattleShip.BLL.Requests
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public override bool Equals(object obj)
        {
            var otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == XCoordinate &&
                   otherCoordinate.YCoordinate == YCoordinate;
        }

        public override int GetHashCode()
        {
            var uniqueHash = XCoordinate + YCoordinate + "00";
            return (Convert.ToInt32(uniqueHash));
        }
    }
}