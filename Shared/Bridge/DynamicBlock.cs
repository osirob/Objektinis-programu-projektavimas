using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Shared.Prototype;

namespace Shared.Bridge
{
    public abstract class DynamicBlock : MapObject
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Color color;
        public string tag;
        public string name;

        public abstract void affectPlayer();
        public abstract void colorize();

        public MapObject makeCopy()
        {
            return (MapObject)this.MemberwiseClone();
        }
    }
}