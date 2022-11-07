using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public abstract class Bullet
    {
        string Tag { get; set; }
        public abstract int CalculateWidth(int standartWidth);
        public abstract int CalculateHeight(int standartHeight);
    }
}
