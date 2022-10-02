using Server.Src.Interfaces;

namespace Server.Src.Classes
{
    public class Coin : ICollectable
    { 
        public int Value { get; set; }
        public int XCoord { get; set; }

        public Coin(int value, int xcoord)
        {
            this.Value = value;
            this.XCoord = xcoord;
        }
    }
}
