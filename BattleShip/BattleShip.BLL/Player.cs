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