using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Shared.Prototype;

namespace Shared.Shared
{
    public class MapEntity : MapObject
    {
        private int posX;
        private int posY;
        private int sizeX;
        private int sizeY;
        private Color color;
        private string tag;
        private string name;
        public MapEntity()
        {
            
        }

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
        public void setPosY(int y)
        {
            this.posY = y;
        }
        public Color getColor()
        {
            return this.color;
        }
        public void setColor(Color color)
        {
            this.color = color;
        }
        public int getPosY()
        {
            return this.posY;
        }
        public int getSizeX()
        {
            return this.sizeX;
        }
        public void setSizeX(int x)
        {
            this.sizeX = x;
        }
        public void setSizeY(int y)
        {
            this.sizeY = y;
        }
        public int getSizeY()
        {
            return this.sizeY;
        }
        public string getTag()
        {
            return this.tag;
        }
        public void setTag(string tag)
        {
            this.tag = tag;
        }
        public string getName()
        {
            return this.name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public MapObject makeCopy()
        {
            return (MapEntity)this.MemberwiseClone();
        }
    }
}
