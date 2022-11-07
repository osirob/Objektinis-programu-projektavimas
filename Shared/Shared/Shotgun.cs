using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Shotgun : IShooting
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int Price { get; } = 400;
        public int AmmoPrice { get; } = 45;
        public Shotgun(string name)
        {
            Name = name;
        }

        public int Shoot(int shootingPower)
        {
            return shootingPower * 3;
        }

        public void AddAmmunition(int ammoCount)
        {
            this.Ammunition += ammoCount;
        }
    }
}
