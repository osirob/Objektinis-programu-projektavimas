using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Pistol : IShooting
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int AmmoPrice { get; } = 25;
        public int Price { get; } = 200;

        public Pistol(string name)
        {
            Name = name;
        }

        public int Shoot(int shootingPower)
        {
            return shootingPower * 1;
        }

        public void AddAmmunition(int ammoCount)
        {
            this.Ammunition += ammoCount;
        }
    }
}
