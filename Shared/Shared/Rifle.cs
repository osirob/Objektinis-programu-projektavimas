using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Rifle : IShooting
    {
        private string Name { get; set; }
        public Rifle(string name)
        {
            Name = name;
        }
        public int Shoot(int shootingPower)
        {
            return shootingPower * 4;
        }
    }
}
