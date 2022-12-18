using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ChainOfResponsibility
{
    internal class BlockPositionHandler : BlockHandler
    {

        public BlockPositionHandler()
        {
        }

        public override MapEntity Handle(MapEntity mapEntity)
        {
            Random random = new Random();
            int posX = random.Next(1, 1100);
            int posY = random.Next(1, 630);
            posY += random.Next(550, 600) / ((1 / (posY + 1)) + 1);
            if (posY >= 630)
            {
                posY = 630;
            }
            mapEntity.setPosX(posX);
            mapEntity.setPosY(posY);

            return HandleNext(mapEntity);
        }
    }
}