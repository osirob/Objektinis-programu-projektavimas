using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    internal class Bazooka : IShooting
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int Price { get; } = 500;
        public int AmmoPrice { get; } = 55;
        public Bazooka(string name)
        {
            Name = name;
        }
        public int Shoot(int shootingPower)
        {
            return shootingPower * 4;
        }

        public void AddAmmunition(int ammoCount)
        {
            this.Ammunition += ammoCount;
        }
    }
}
