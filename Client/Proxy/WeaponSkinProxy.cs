using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Proxy
{
    public class WeaponSkinProxy : IWeapon
    {
        private WeaponSkin weaponSkin = new WeaponSkin();
        public int Pistol(int defaultValue)
        {
            return weaponSkin.Pistol(defaultValue);
        }

        public int Riffle(int defaultValue)
        {
            return weaponSkin.Riffle(defaultValue);
        }

        public int Shotgun(int defaultValue)
        {
            return weaponSkin.Shotgun(defaultValue);
        }

        public int Bazooka(int defaultValue)
        {
            return weaponSkin.Bazooka(defaultValue);
        }
    }
}
