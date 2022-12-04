using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public class DamageReduceBonuses :AbstractBonuses
    {
        public bool Active;
        GameManagerServer gameManagerServer;
        public DamageReduceBonuses()
        {
            Active = false;
            gameManagerServer = GameManagerServer.Instance;
        }


        public void ActivateBoost(int id)
        {
            if (!Active)
            {
                Active = true;
                gameManagerServer.GetPlayer(id).Bonuses.DamageReducerBonus = 2;
                this.mediator.Notify(this, "Damage", id);
            }
        }

        public void DeactivateBoost(int id)
        {
            Active = false;
            gameManagerServer.GetPlayer(id).Bonuses.DamageReducerBonus = 1;
        }
    }
}
