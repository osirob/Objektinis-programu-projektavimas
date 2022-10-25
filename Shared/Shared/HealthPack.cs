using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class HealthPack : ICollectable
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Tag { get; set; }

        public HealthPack(int value, int xcoord, int ycoord, int id)
        {
            this.Value = value;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.Tag = "healthpack";
            this.Id = id;
        }
    }
}
