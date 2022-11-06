using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Shotgun : IShooting
    {
        private string Name { get; set; }

        public Shotgun(string name)
        {
            Name = name;
        }

        public int Shoot(int shootingPower)
        {
            return shootingPower * 3;
        }
    }
}
