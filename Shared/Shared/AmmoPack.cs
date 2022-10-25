using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class AmmoPack
    {
        public int Id { get; set; }
        public int ammoCount { get; set; }
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public string Tag { get; set; }
        public AmmoPack(int count, int xcoord, int ycoord, int id)
        {
            this.ammoCount = count;
            this.xCoord = xcoord;
            this.yCoord = ycoord;
            this.Tag = "ammo";
            this.Id = id;
        }
    }
}
