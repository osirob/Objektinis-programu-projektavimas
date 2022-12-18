using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Shared.Prototype;
using Shared.Bridge;
using Shared.ChainOfResponsibility;

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
            MapEntity block = new MapEntity();
            BlockHandler blockHandler = new BlockSizeHandler(block);
            blockHandler.setNextHandler(new BlockPositionHandler())
                        .setNextHandler(new BlockColorHandler())
                        .setNextHandler(new BlockNameHandler());
            for (int i = 0; i <= 1000; i++)
            {
                blockHandler.Handle(block);
                MapEntity newBlock = new MapEntity(block.getPosX(), block.getPosY(), block.getSizeX(), block.getSizeY(), block.getColor(), block.getTag(), block.getName());
                this.map.addMapEntity(newBlock);
            }
        }

        public void buildFloatingPlatforms()
        {
            MapObject floatingPlatform1 = new BouncyPlatform(new HealingBlock(170, 450, 216, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform1);
            MapObject floatingPlatform2 = new StickyPlatform(new MaliciousBlock(650, 400, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform2);
            MapObject floatingPlatform3 = new StickyPlatform(new HealingBlock(300, 350, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform3);
            MapObject floatingPlatform4 = new StickyPlatform(new HealingBlock(400, 300, 150, 20, "floatingPlatform1"));
            this.map.addFloatingPlatform(floatingPlatform4);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
