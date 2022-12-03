using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public class SpeedBonuses :AbstractBonuses
    {
        public bool Active = false;
        GameManagerServer gameManagerServer = GameManagerServer.Instance;

        public void ActivateBoost(int id)
        {
            if (!Active)
            {
                Active = true;
                gameManagerServer.GetPlayer(id).Bonuses.SpeedBonus = 1.5;
                this.mediator.Notify(this, "Speed", id);
            }
        }

        public void DeactivateBoost(int id)
        {
            Active = false;
            gameManagerServer.GetPlayer(id).Bonuses.SpeedBonus = 1;
        }


    }
}
