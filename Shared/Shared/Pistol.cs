using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Pistol : IShooting
    {
        private string Name { get; set; }

        public Pistol(string name)
        {
            Name = name;
        }

        public int Shoot(int shootingPower)
        {
            return shootingPower * 2;
        }
    }
}
