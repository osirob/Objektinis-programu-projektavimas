using System;
using System.Collections.Generic;
using System.Text;
using Shared.Builder;

namespace Shared.Shared
{
    public class Map : MapPlan
    {
        private List<MapEntity> mapEntities = new List<MapEntity>();

        public List<MapEntity> getMapEntities()
        {
            return this.mapEntities;
        }
        public MapPlan addMapEntity(MapEntity mapEntity)
        {
            this.mapEntities.Add(mapEntity);
            return this;
        }
    }
}
