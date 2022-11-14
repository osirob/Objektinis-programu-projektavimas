using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Bridge
{
    public class MaliciousBlock : DynamicBlock
    {
        public MaliciousBlock(int x, int y, int sizeX, int sizeY, string name)
        {
            base.x = x;
            base.y = y;
            base.sizeX = sizeX;
            base.sizeY = sizeY;
            base.name = name;
            color = Color.OrangeRed;
            base.tag = "malicious_";
        }
        public override void affectPlayer()
        {
            Console.WriteLine("Damaging player");
        }

        public override void colorize()
        {
            Console.WriteLine("Horific red colors");
        }
    }
}