using System;
using System.Collections.Generic;
using System.Text;
using Shared.Builder;
using Shared.Prototype;

namespace Shared.Shared
{
    public class Map : MapPlan
    {
        private List<MapObject> mapEntities = new List<MapObject>();
        private List<MapObject> floatingPlatforms = new List<MapObject>();

        public List<MapObject> getMapEntities()
        {
            return this.mapEntities;
        }
        public List<MapObject> getFloatingPlatforms()
        {
            return this.floatingPlatforms;
        }
        public MapPlan addMapEntity(MapObject mapEntity)
        {
            this.mapEntities.Add(mapEntity);
            return this;
        }
        public MapPlan addFloatingPlatform(MapObject floatingPlatform)
        {
            this.floatingPlatforms.Add(floatingPlatform);
            return this;
        }
    }
}
