using Shared.Shared;

namespace Shared.Shared
{
    public class Coin : ICollectable
    { 
        public int Value { get; set; }
        public int XCoord { get; set; }
        public string Tag { get; set; }

        public Coin(int value, int xcoord)
        {
            this.Value = value;
            this.XCoord = xcoord;
            this.Tag = "coin";
        }
    }
}
