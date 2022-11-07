using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.Builder
{
    public interface MapBuilder
    {
        public void buildPlayers();
        public void buildGround();
        public void buildFloatingPlatforms();
        public Map getMap();
    }
}
