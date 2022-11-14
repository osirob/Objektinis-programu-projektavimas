using Shared.Prototype;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Bridge
{
    public class StickyPlatform : FloatingPlatform, MapObject
    {
        public StickyPlatform(DynamicBlock block) : base(block)
        {
            base.block = block;
            base.block.color = Color.RosyBrown;
            base.block.tag += "sticky";
        }
        public override void move()
        {
            Console.WriteLine("Sticky");
        }
        public MapObject makeCopy()
        {
            return this;
        }
    }
}

