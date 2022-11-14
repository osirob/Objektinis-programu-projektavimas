//using Client;
using Shared.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Player : Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isReady { get; set; }
        public bool isDead { get; set; }
        public int HasCoinValue { get; set; } = 0;
        public int Health = 100;
        protected Position position = new Position();

        public List<DamageDealed> damageDealedList = new List<DamageDealed>();

        public override void ReportAboutDeath(int id)
        {
            Console.WriteLine("It was reported that {0} died", id);
            if(this.Id != id && isDead == false)
            {
                //Add coints to player

                //Remove from damageDealedLIst

                var element = damageDealedList.Where(x=>x.PlayerId == id).FirstOrDefault();
                
                if (element != null)
                {
                    Console.WriteLine("Coint:" + HasCoinValue);
                    HasCoinValue += element.Damage / 2;
                    damageDealedList.Remove(element);
                    Console.WriteLine("Coint:" + HasCoinValue);
                }
            }
            else
            {
                if (this.subject != null && isDead == false)
                {
                    this.isDead = true;
                    this.subject.ReceiveAboutDeath(id);
                }
            }


        }

        public void Die()
        {
            this.ReportAboutDeath(this.Id);
            //this.isDead = true;
        }

        public void Revive()
        {
            this.isDead = true;
        }

        public void AddDamagesBonus(int damageBonus, int damagePlayerIndex)
        {
            Console.WriteLine(damageBonus);
            if (this.damageDealedList.Where(x => x.PlayerId == damagePlayerIndex).FirstOrDefault() == null)
            {
                DamageDealed dm = new DamageDealed(damagePlayerIndex);
                this.damageDealedList.Add(dm);
                this.damageDealedList.Where(x => x.PlayerId == damagePlayerIndex).FirstOrDefault().AddBonus(damageBonus);
            }
            else
            {
                this.damageDealedList.Where(x => x.PlayerId == damagePlayerIndex).FirstOrDefault().AddBonus(damageBonus);
            }
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine(damage);
            this.Health -= damage;
        }

        public void UndoDamage(int damage)
        {
            this.Health += damage;
        }

        public void SetCords(string cords)
        {
            position.SetCordinates(cords);
        }

        public void AddMoney(int value)
        {
            this.HasCoinValue = this.HasCoinValue + value;
            Console.WriteLine(HasCoinValue);
        }
    }
}
