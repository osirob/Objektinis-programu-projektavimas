using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.ChainOfResponsibility
{
    public abstract class BlockHandler
    {
        private BlockHandler next;

        public BlockHandler setNextHandler(BlockHandler next)
        {
            this.next = next;
            return next;
        }

        public abstract MapEntity Handle(MapEntity mapEntity);

        protected MapEntity HandleNext(MapEntity mapEntity)
        {
            if (next == null)
            {
                return mapEntity;
            }
            return next.Handle(mapEntity);
        }
    }
}
