using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.Builder
{
    internal class ThirdLevelMapBuilder : MapBuilder
    {
        private Map map;
        public ThirdLevelMapBuilder()
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
                MapEntity dirtBlock = new MapEntity(i, 630, 50, 50, Color.DarkRed, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 100; i <= 985; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 580, 50, 50, Color.DarkRed, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 200; i <= 885; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 530, 50, 50, Color.DarkRed, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
            for (int i = 300; i <= 785; i += 10)
            {
                MapEntity dirtBlock = new MapEntity(i, 480, 50, 50, Color.DarkRed, "platform", "dirtBlock" + i);
                this.map.addMapEntity(dirtBlock);
            }
        }

        public void buildPlayers()
        {
            MapEntity player1 = new MapEntity(38, 527, 40, 80, Color.Red, "player1", "player1");
            MapEntity player2 = new MapEntity(950, 527, 40, 80, Color.Blue, "player2", "player2");
            this.map.addMapEntity(player1);
            this.map.addMapEntity(player2);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
