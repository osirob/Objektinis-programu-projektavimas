using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.Control;

namespace Shared.Composite
{
    public class CompositeKit : HealthKit
    {
        List<HealthKit> list = new List<HealthKit>();
        public CompositeKit(int value, int xcoord, int ycoord, int id) : base(value, xcoord, ycoord, id) { }
        public override void Add(HealthKit healthKit) { list.Add(healthKit); }
        public override void Remove(HealthKit healthKit) { list.Remove(healthKit); }
        public override void Spawn(ControlCollection control, List<HealthKit> healthKits)
        {
            foreach(HealthKit kit in list)
            {
                kit.Spawn(control, healthKits);
            }
        }
    }
}
