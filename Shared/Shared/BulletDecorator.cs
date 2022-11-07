using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public abstract class BulletDecorator : Bullet
    {
        protected Bullet _bullet;

        public BulletDecorator(Bullet bullet)
        {
            _bullet = bullet;
        }

        public override int CalculateHeight(int standartHeight)
        {
            return _bullet.CalculateHeight(standartHeight);
        }

        public override int CalculateWidth(int standartWidth)
        {
            return _bullet.CalculateWidth(standartWidth);
        }
    }
}
