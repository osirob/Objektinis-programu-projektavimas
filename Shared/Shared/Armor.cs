using Shared.Shared;

namespace Shared.Shared
{
    public class Armor : ICollectable
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Tag { get; set; }

        public Armor(int strength, int xcoord, int ycoord, int id)
        {
            this.Strength = strength;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.Tag = "armor";
            this.Id = id;
        }
    }
}
