using Shared.Shared;

namespace Shared.Shared
{
    public class Coin : ICollectable
    { 
        public int Id { get; set; }
        public int Value { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Tag { get; set; }

        public Coin(int value, int xcoord, int ycoord, int id)
        {
            this.Value = value;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.Tag = "coin";
            this.Id = id;
        }
    }
}
