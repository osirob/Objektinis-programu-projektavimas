using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Memento
{
    public class TotalMoneyOriginator
    {
        private int totalMoney = 0;

        public void addMoney(int money)
        {
            this.totalMoney += money;
        }

        public TotalMoneyMemento takeSnapshot()
        {
            return new TotalMoneyMemento(this.totalMoney);
        }

        public void restore(TotalMoneyMemento memento)
        {
            this.totalMoney = memento.getSavedMoney();
        }
    }
}