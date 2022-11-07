using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Builder
{
    public interface MapPlan
    {
        public List<MapEntity> getMapEntities();
        public MapPlan addMapEntity(MapEntity mapEntity);
    }
}
