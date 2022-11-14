using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Bridge
{
    public abstract class FloatingPlatform
    {
        public DynamicBlock block;

        public FloatingPlatform(DynamicBlock block)
        {
            this.block = block;
        }

        public abstract void move();
    }
}