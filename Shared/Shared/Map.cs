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

        public List<MapObject> getMapEntities()
        {
            return this.mapEntities;
        }
        public MapPlan addMapEntity(MapObject mapEntity)
        {
            this.mapEntities.Add(mapEntity);
            return this;
        }
    }
}
