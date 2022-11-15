using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class BazookaBullet : Bullet
    {
        public string Tag { get; set; }
        public override int CalculateWidth(int standartWidth)
        {
            return standartWidth * 15;
        }

        public override int CalculateHeight(int standartHeight)
        {
            return standartHeight * 30;
        }
    }
}
