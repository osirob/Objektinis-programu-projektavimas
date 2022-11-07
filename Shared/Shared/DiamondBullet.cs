using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class DiamondBullet : BulletDecorator
    {
        public DiamondBullet(Bullet bullet) : base(bullet)
        {

        }
        public override int CalculateHeight(int standartHeight)
        {
            base.CalculateHeight(standartHeight);

            return base.CalculateHeight(standartHeight) + 8;
        }

        public override int CalculateWidth(int standartWidth)
        {
            base.CalculateWidth(standartWidth);

            return base.CalculateWidth(standartWidth) + 8;
        }
    }
}
