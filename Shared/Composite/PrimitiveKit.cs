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
        public override void Spawn(Control control, List<HealthKit> healthKits)
        {
            healthKits.Add(this);
            control.Controls.Add(new PictureBox {
                Tag = this.Tag,
                Size = new Size(40, 40),
                Location = new Point(this.XCoord, this.YCoord),
                BackColor = Color.White            
            });
        }
    }
}
