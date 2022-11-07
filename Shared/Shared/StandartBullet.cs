using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class StandartBullet : BulletDecorator
    {
        public StandartBullet(Bullet bullet) : base(bullet)
        {
        }

        public override int CalculateHeight(int standartHeight)
        {
            base.CalculateHeight(standartHeight);

            return base.CalculateHeight(standartHeight);
        }

        public override int CalculateWidth(int standartWidth)
        {
            base.CalculateWidth(standartWidth);

            return base.CalculateWidth(standartWidth);
        }
    }
}
