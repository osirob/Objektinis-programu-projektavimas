using Shared.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class MapDirector
    {
        private MapBuilder mapBuilder;

        public MapDirector(MapBuilder mapBuilder)
        {
            this.mapBuilder = mapBuilder;
        }

        public void buildMap()
        {
            this.mapBuilder.buildBlockSize();
            this.mapBuilder.buildMapGrid();
        }

        public Map getMap()
        {
            return this.mapBuilder.getMap();
        }
    }
}
