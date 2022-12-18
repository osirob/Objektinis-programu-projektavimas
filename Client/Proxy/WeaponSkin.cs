using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Proxy
{
    public class WeaponSkin: IWeapon
    {
        public int Pistol(int defaultValue)
        {
            return defaultValue;
        }

        public int Riffle(int defaultValue)
        {
            return defaultValue + 4;
        }

        public int Shotgun(int defaultValue)
        {
            return defaultValue + 8;
        }

        public int Bazooka(int defaultValue)
        {
            return defaultValue + 12;
        }
    }
}
