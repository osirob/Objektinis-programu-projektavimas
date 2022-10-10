using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class HealthPack : ICollectable
    {
        public int Value { get; set; }
        public int XCoord { get; set; }
        public string Tag { get; set; }

        public HealthPack(int value, int xcoord)
        {
            this.Value = value;
            this.XCoord = xcoord;
            this.Tag = "healthpack";
        }
    }
}
