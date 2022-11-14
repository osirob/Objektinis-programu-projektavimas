using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Rifle : IShooting
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int Price { get; } = 300;
        public int AmmoPrice { get; } = 35;
        public Rifle(string name)
        {
            Name = name;
        }
        public int Shoot(int shootingPower)
        {
            return shootingPower * 2;
        }

        public void AddAmmunition(int ammoCount)
        {
            this.Ammunition += ammoCount;
        }
    }
}
