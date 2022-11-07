using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Builder
{
    internal class SecondLevelMapBuilder : MapBuilder
    {
        private Map map;
        public SecondLevelMapBuilder()
        {
            this.map = new Map();
        }
        public void buildFloatingPlatforms()
        {
            
        }

        public void buildGround()
        {
            for (int i = 0; i <= 1085; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 830, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 100; i <= 985; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 780, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 200; i <= 885; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 730, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 300; i <= 785; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 680, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 400; i <= 685; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 630, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 500; i <= 585; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 580, 50, 50, Color.Violet, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
        }

        public void buildPlayers()
        {
            MapEntity player1 = new MapEntity(38, 727, 40, 80, Color.Red, "player1", "player1");
            MapEntity player2 = new MapEntity(950, 727, 40, 80, Color.Blue, "player2", "player2");
            this.map.addMapEntity(player1);
            this.map.addMapEntity(player2);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
