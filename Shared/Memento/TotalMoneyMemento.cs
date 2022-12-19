using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Memento
{
    public class TotalMoneyMemento
    {
        private int totalMoney;

        public TotalMoneyMemento(int moneyToSave)
        {
            this.totalMoney = moneyToSave;
        }

        public int getSavedMoney()
        {
            return this.totalMoney;
        }
    }
}