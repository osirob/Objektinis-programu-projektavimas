using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public class JumpBonuses : AbstractBonuses
    {
        public bool Active;
        GameManagerServer gameManagerServer;

        public JumpBonuses()
        {
            Active = false;
            gameManagerServer = GameManagerServer.Instance;
        }

        public void ActivateBoost(int id)
        {
            if (!Active)
            {
                Active = true;
                gameManagerServer.GetPlayer(id).Bonuses.JumpBonus = 2;
                this.mediator.Notify(this, "Jump", id);
            }
        }

        public void DeactivateBoost(int id)
        {
            Active = false;
            gameManagerServer.GetPlayer(id).Bonuses.JumpBonus = 1;
        }
    }
}
