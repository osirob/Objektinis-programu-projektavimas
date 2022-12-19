using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Composite
{
    public class PrimitiveKit : HealthKit
    {
        public PrimitiveKit(int value, int xcoord, int ycoord, int id) : base(value, xcoord, ycoord, id) {}

        public override void Add(HealthKit healthKit) { return; }
        public override void Remove(HealthKit healthKit) { return; }
        public override void Spawn(List<HealthKit> healthKits)
        {
            healthKits.Add(this);
        }
    }
}
