using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Bazooka : IShooting
    {
        private string Name { get; set; }
        public Bazooka(string name)
        {
            Name = name;
        }
        public int Shoot(int shootingPower)
        {
            return shootingPower * 6;
        }
    }
}
