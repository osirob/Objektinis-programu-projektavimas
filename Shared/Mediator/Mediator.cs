using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public abstract class Mediator
    {
        public abstract void Notify(object sender, string bonusesType, int playerId);
    }
}
