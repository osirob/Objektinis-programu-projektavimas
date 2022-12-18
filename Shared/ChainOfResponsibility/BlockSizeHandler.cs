using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.ChainOfResponsibility
{
    internal class BlockSizeHandler : BlockHandler
    {
        private MapEntity mapEntity;
        public BlockSizeHandler(MapEntity mapEntity)
        {
            this.mapEntity = mapEntity;
        }

        public override MapEntity Handle(MapEntity mapEntity)
        {
            Random random = new Random();
            int sizeX = random.Next(60, 100);
            int sizeY = random.Next(60, 100);
            this.mapEntity.setSizeX(sizeX);
            this.mapEntity.setSizeY(sizeY);

            return HandleNext(this.mapEntity);
        }
    }
}
