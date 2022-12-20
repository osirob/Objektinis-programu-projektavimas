using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Flyweight
{
    internal class FlyweightFactory
    {
        private Dictionary<string, IShooting> flyweights { get; set; } = new Dictionary<string, IShooting>();
        public FlyweightFactory()
        {
            flyweights.Add("P", new Pistol("Pistol"));
            flyweights.Add("R", new Rifle("Riffle"));
            flyweights.Add("S", new Shotgun("Shotgun"));
            flyweights.Add("B", new Bazooka("Bazooka"));
        }
        public IShooting GetFlyweight(string key)
        {
            return ((IShooting)flyweights[key]);
        }
    }
}
