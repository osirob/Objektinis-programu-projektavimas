using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    internal interface IShooting
    {
        int Ammunition { get; set; }
        string Name { get; set; }
        int Shoot(int shootingPower);
        void AddAmmunition(int ammoCount);
    }
}
