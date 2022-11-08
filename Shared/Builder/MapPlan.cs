﻿using Shared.Prototype;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Builder
{
    public interface MapPlan
    {
        public List<MapObject> getMapEntities();
        public MapPlan addMapEntity(MapObject mapEntity);
    }
}
