using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Builder
{
    public class FirstLevelMapBuilder : MapBuilder
    {
        private Map map;

        public FirstLevelMapBuilder()
        {
            this.map = new Map();
        }
        public void buildBlockSize()
        {
            map.setBlockSize(10);
        }

        public void buildMapGrid()
        {
            map.setMapGrid(new int[1]);
        }

        public Map getMap()
        {
            return this.map;
        }
    }
}
