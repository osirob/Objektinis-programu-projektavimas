using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shared.ChainOfResponsibility
{
    internal class BlockColorHandler : BlockHandler
    {
        public BlockColorHandler(){

        }

        public override MapEntity Handle(MapEntity mapEntity)
        {
            mapEntity.setColor(Color.FromArgb(mapEntity.getPosY() * 255 / 630, mapEntity.getPosY() * 127 / 630, 0));
            return HandleNext(mapEntity);
        }
    }
}