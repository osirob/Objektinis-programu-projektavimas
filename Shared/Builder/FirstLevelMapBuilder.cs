using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Shared.Prototype;

namespace Shared.Builder
{
    public class FirstLevelMapBuilder : MapBuilder
    {
        private Map map;

        public FirstLevelMapBuilder()
        {
            this.map = new Map();
        }
        public void buildPlayers()
        {
            MapObject player1 = new MapEntity(38, 727, 40, 80, Color.Red, "player1", "player1");
            MapObject player2 = new MapEntity(950, 727, 40, 80, Color.Blue, "player2", "player2");
            this.map.addMapEntity(player1);
            this.map.addMapEntity(player2);
        }

        public void buildGround()
        {
            MapObject dirtBlock = new MapEntity(0, 830, 50, 50, Color.Brown, "platform", "dirtBlock" + 0);
            MapObject grassBlock = new MapEntity(0, 820, 10, 10, Color.Green, "platform", "grassBlock" + 0);
            Console.WriteLine("Original dirt block hashcode: " + dirtBlock.GetHashCode());
            Console.WriteLine("Original grass block hashcode: " + grassBlock.GetHashCode());
            for (int i = 0; i <= 1085; i += 10)
            {
                MapObject dirtBlockClone = dirtBlock.makeCopy();
                MapObject grassBlockClone = grassBlock.makeCopy();
                Console.WriteLine("Clone dirt block hashcode: " + dirtBlockClone.GetHashCode());
                Console.WriteLine("Clone grass block hashcode: " + grassBlockClone.GetHashCode());
                dirtBlockClone.setPosX(i);
                grassBlockClone.setPosX(i);
                this.map.addMapEntity(dirtBlockClone);
                this.map.addMapEntity(grassBlockClone);
            }
        }

        public void buildFloatingPlatforms()
        {
            MapObject floatingPlatform1 = new MapEntity(170, 650, 216, 20, Color.BurlyWood, "platform", "floatingPlatform1");
            MapObject floatingPlatform2 = new MapEntity(650, 600, 150, 20, Color.BurlyWood, "platform", "floatingPlatform2");
            MapObject floatingPlatform3 = new MapEntity(200, 550, 300, 20, Color.BurlyWood, "platform", "floatingPlatform3");
            MapObject floatingPlatform4 = new MapEntity(350, 450, 300, 20, Color.BurlyWood, "platform", "floatingPlatform4");
            this.map.addMapEntity(floatingPlatform1);
            this.map.addMapEntity(floatingPlatform2);
            this.map.addMapEntity(floatingPlatform3);
            this.map.addMapEntity(floatingPlatform4);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
