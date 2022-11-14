using Shared.Prototype;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Bridge
{
    public class BouncyPlatform : FloatingPlatform, MapObject
    {
        public BouncyPlatform(DynamicBlock block) : base(block)
        {
            base.block = block;
            base.block.color = Color.LightGoldenrodYellow;
            base.block.tag += "bouncy";
        }

        public override void move()
        {
            Console.WriteLine("Bouncy");
        }
        public MapObject makeCopy()
        {
            return this;
        }
    }
}