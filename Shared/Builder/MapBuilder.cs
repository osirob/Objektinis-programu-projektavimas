using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.Builder
{
    public interface MapBuilder
    {
        public void buildBlockSize();
        public void buildMapGrid();

        public Map getMap();
    }
}
