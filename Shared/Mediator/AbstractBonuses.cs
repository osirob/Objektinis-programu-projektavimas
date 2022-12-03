using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public abstract class AbstractBonuses
    {
        protected Mediator mediator;

        public AbstractBonuses(Mediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
