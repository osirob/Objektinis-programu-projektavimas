using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class AmmoPack
    {
        public int ammoCount { get; set; }
        public int xCoord { get; set; }
        public AmmoPack(int count, int coord)
        {
            this.ammoCount = count;
            this.xCoord = coord;
        }
    }
}
