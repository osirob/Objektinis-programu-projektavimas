using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mediator
{
    public class ConcreateMediator : Mediator
    {
        private SpeedBonuses _speedBonuses;
        private JumpBonuses _jumpBonuses;
        private DamageReduceBonuses _damageReduceBonuses;

        public ConcreateMediator(SpeedBonuses speedBonuses, JumpBonuses jumpBonuses, DamageReduceBonuses damageReduceBonuses)
        {
            _speedBonuses = speedBonuses;
            _speedBonuses.SetMediator(this);
            _jumpBonuses = jumpBonuses;
            _jumpBonuses.SetMediator(this);
            _damageReduceBonuses = damageReduceBonuses;
            _damageReduceBonuses.SetMediator(this);
        }

        public override void Notify(object sender, string bonusesType,int playerId)
        {
            switch (bonusesType)
            {
                case "Speed":
                    {
                        this._speedBonuses.ActivateBoost(playerId);
                        this._jumpBonuses.DeactivateBoost(playerId);
                        this._damageReduceBonuses.DeactivateBoost(playerId);
                        break;
                    }
                case "Jump":
                    {
                        this._speedBonuses.DeactivateBoost(playerId);
                        this._jumpBonuses.ActivateBoost(playerId);
                        this._damageReduceBonuses.DeactivateBoost(playerId);
                        break;
                    }
                case "Damage":
                    {
                        this._speedBonuses.DeactivateBoost(playerId);
                        this._jumpBonuses.DeactivateBoost(playerId);
                        this._damageReduceBonuses.ActivateBoost(playerId);
                        break;
                    }
                default: break;
            }
        }
    }
}
