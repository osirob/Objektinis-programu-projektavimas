using System;
using System.Collections.Generic;
using System.Text;


namespace Shared.Shared
{
    public abstract class Unit : Observer.Observer
    {
        protected Position position = new Position();

        public override void UpdateCords(string cords)
        {
            position.SetCordinates(cords);
        }
    }
}
