using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class AmmoPack : ICollectable
    {
        public int Id { get; set; }
        public int ammoCount { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Tag { get; set; }
        public AmmoPack(int count, int xcoord, int ycoord, int id)
        {
            this.ammoCount = count;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.Tag = "ammo";
            this.Id = id;
        }
    }
}
