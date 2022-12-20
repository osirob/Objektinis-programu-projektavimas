using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Shared.Composite
{
    internal abstract class HealthKit
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
        public abstract void Spawn(ref List<HealthKit> healthKits);
        public abstract void Print();
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
