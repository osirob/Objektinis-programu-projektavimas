using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Shared
{
    public class MapEntity
    {
        private int posX;
        private int posY;
        private int sizeX;
        private int sizeY;
        private Color color;
        private string tag;
        private string name;

        public MapEntity(int posX, int posY, int sizeX, int sizeY, Color color, string tag, string name)
        {
            this.posX = posX;
            this.posY = posY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.color = color;
            this.tag = tag;
            this.name = name;
        }

        public int getPosX()
        {
            return this.posX;
        }
        public void setPosX(int x)
        {
            this.posX = x;
        }
        public Color getColor()
        {
            return this.color;
        }
        public int getPosY()
        {
            return this.posY;
        }
        public int getSizeX()
        {
            return this.sizeX;
        }
        public int getSizeY()
        {
            return this.sizeY;
        }
        public string getTag()
        {
            return this.tag;
        }
        public string getName()
        {
            return this.name;
        }
    }
}
