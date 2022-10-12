using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Position
    {
        public int x { get; set; } = -1;
        public int y { get; set; } = -1;


        public void SetCordinates(string cord)
        {
            string[] split = cord.Split(',');

            x = Convert.ToInt32(split[0]);
            y = Convert.ToInt32(split[1]);
        }
    }
}
