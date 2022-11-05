using System;
using System.Collections.Generic;
using System.Text;
using Shared.Builder;

namespace Shared.Shared
{
    public class Map : MapPlan
    {
        private int blockSize;
        private int[] mapGrid;

        public int getBlockSize()
        {
            return this.blockSize;
        }
        public MapPlan setBlockSize(int blockSize)
        {
            this.blockSize = blockSize;
            return this;
        }
        public int[] getMapGrid()
        {
            return this.mapGrid;
        }
        public MapPlan setMapGrid(int[] mapGrid)
        {
            this.mapGrid = mapGrid;
            return this;
        }
    }
}
