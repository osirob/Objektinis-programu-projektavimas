using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Proxy
{
    public interface IWeapon
    {
        int Pistol(int defaultValue);
        int Riffle(int defaultValue);
        int Shotgun(int defaultValue);
        int Bazooka(int defaultValue);
    }
}
