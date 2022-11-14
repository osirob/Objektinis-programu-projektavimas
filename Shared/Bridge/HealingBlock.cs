using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Bridge
{
    public class HealingBlock : DynamicBlock
    {
        public HealingBlock(int x, int y, int sizeX, int sizeY, string name)
        {
            base.x = x;
            base.y = y;
            base.sizeX = sizeX;
            base.sizeY = sizeY;
            base.name = name;
            color = Color.LawnGreen;
            base.tag = "healing_";
        }
        public override void affectPlayer()
        {
            Console.WriteLine("Healing player");
        }

        public override void colorize()
        {
            Console.WriteLine("Pretty green colors");
        }
    }
}