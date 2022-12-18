using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ChainOfResponsibility
{
    internal class BlockNameHandler : BlockHandler
    {
        public BlockNameHandler()
        {
        }

        public override MapEntity Handle(MapEntity mapEntity)
        {
            mapEntity.setName(mapEntity.getPosX() + mapEntity.getPosY() + "_block");
            mapEntity.setTag("platform");
            return HandleNext(mapEntity);
        }
    }
}