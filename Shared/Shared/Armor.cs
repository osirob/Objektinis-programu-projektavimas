using Shared.Shared;

namespace Shared.Shared
{
    public class Armor : ICollectable
    {
        public int Strength { get; set; }
        public int XCoord { get; set; }
        public string Tag { get; set; }

        public Armor(int strength, int xcoord)
        {
            this.Strength = strength;
            this.XCoord = xcoord;
            this.Tag = "armor";
        }
    }
}
