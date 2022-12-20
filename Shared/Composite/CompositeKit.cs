using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Composite
{
    internal class CompositeKit : HealthKit
    {
        List<HealthKit> list { get; set; } = new List<HealthKit>();
        public CompositeKit(int value, int xcoord, int ycoord, int id) : base(value, xcoord, ycoord, id) { }
        public override void Add(HealthKit healthKit) { list.Add(healthKit); }
        public override void Remove(HealthKit healthKit) { list.Remove(healthKit); }
        public override void Spawn(ref List<HealthKit> healthKits)
        {
            foreach (HealthKit kit in list)
            {
                kit.Spawn(ref healthKits);
            }
        }

        public override void Print()
        {
            Console.WriteLine("Entered");
            foreach (var healthKit in list)
            {
                healthKit.Print();
            }
        }
    }
}
