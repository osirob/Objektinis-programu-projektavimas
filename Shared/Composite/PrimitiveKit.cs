using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Composite
{
    internal class PrimitiveKit : HealthKit
    {
        public PrimitiveKit(int value, int xcoord, int ycoord, int id) : base(value, xcoord, ycoord, id) { }

        public override void Add(HealthKit healthKit) { return; }

        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override void Remove(HealthKit healthKit) { return; }
        public override void Spawn(ref List<HealthKit> healthKits)
        {
            healthKits.Add((HealthKit)this);
        }
    }
}
