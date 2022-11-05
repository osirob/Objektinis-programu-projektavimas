using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Builder
{
    public interface MapPlan
    {
        public MapPlan setBlockSize(int blockSize);
        public MapPlan setMapGrid(int[] mapGrid);
    }
}
