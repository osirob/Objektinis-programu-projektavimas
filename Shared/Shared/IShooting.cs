using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public interface IShooting
    {
        int Ammunition { get; set; }
        int Price { get; }
        int AmmoPrice { get; }
        string Name { get; set; }
        int Shoot(int shootingPower);
        void AddAmmunition(int ammoCount);
    }
}
