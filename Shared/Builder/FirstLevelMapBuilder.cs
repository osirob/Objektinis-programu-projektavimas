using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Shared.Prototype;
using Shared.Bridge;

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
            MapObject player1 = new MapEntity(38, 527, 40, 80, Color.Red, "player1", "player1");
            MapObject player2 = new MapEntity(950, 527, 40, 80, Color.Blue, "player2", "player2");
            this.map.addMapEntity(player1);
            this.map.addMapEntity(player2);
        }

        public void buildGround()
        {
            MapObject dirtBlock = new MapEntity(0, 630, 50, 50, Color.Brown, "platform", "dirtBlock" + 0);
            MapObject grassBlock = new MapEntity(0, 620, 10, 10, Color.Green, "platform", "grassBlock" + 0);
            Console.WriteLine("Original dirt block hashcode: " + dirtBlock.GetHashCode());
            Console.WriteLine("Original grass block hashcode: " + grassBlock.GetHashCode());
            for (int i = 0; i <= 1085; i += 10)
            {
                MapEntity dirtBlockClone = (MapEntity)dirtBlock.makeCopy();
                MapEntity grassBlockClone = (MapEntity)grassBlock.makeCopy();
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
            MapObject floatingPlatform1 = new BouncyPlatform(new HealingBlock(170, 500, 216, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform1);
            MapObject floatingPlatform2 = new StickyPlatform(new MaliciousBlock(650, 450, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform2);
            MapObject floatingPlatform3 = new StickyPlatform(new HealingBlock(300, 400, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform3);
            MapObject floatingPlatform4 = new StickyPlatform(new HealingBlock(400, 350, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform4);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
