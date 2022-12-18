using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Composite
{
    public abstract class HealthKit
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Tag { get; set; }

        public HealthKit(int value, int xcoord, int ycoord, int id)
        {
            this.Value = value;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.Tag = "healthkit";
            this.Id = id;
        }

        public abstract void Add(HealthKit healthKit);
        public abstract void Remove(HealthKit healthKit);
        public abstract void Spawn(Control control, List<HealthKit> healthKits);
    }
}
