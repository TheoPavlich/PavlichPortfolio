using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL
{
    public class Player
    {
        public string Name { get; set; }
        public string[,] DisplayBoard { get; set; }
        public int PlayerNum { get; set; }
        public string[,] ShipSetup { get; set; }

    }
}
