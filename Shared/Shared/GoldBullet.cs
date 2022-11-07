using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class GoldBullet : BulletDecorator
    {
        public GoldBullet(Bullet bullet) : base(bullet)
        {
        }

        public override int CalculateHeight(int standartHeight)
        {
            base.CalculateHeight(standartHeight);

            return base.CalculateHeight(standartHeight) + 2;
        }

        public override int CalculateWidth(int standartWidth)
        {
            base.CalculateWidth(standartWidth);

            return base.CalculateWidth(standartWidth) + 2;
        }
    }
}
