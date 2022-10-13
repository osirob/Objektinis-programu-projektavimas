using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class DamageDealed
    {
        public int PlayerId { get; set; }
        public int Damage { get;set; }


        public DamageDealed(int playerId)
        {
            PlayerId = playerId;
            Damage = 0;
        }

        public void AddBonus(int damage)
        {
            this.Damage += damage;
        }
    }
}
