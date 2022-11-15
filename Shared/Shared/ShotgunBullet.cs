using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class ShotgunBullet : Bullet
    {
        public string Tag { get; set; }
        public override int CalculateWidth(int standartWidth)
        {
            return standartWidth * 12;
        }

        public override int CalculateHeight(int standartHeight)
        {
            return standartHeight * 12;
        }
    }
}
