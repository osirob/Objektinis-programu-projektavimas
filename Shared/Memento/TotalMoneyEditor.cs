using System;
using System.Collections.Generic;
using System.Text;
using Shared.Memento;

namespace Shared.Memento
{
    public class TotalMoneyEditor
    {
        private List<TotalMoneyMemento> stateHistory;
        private TotalMoneyOriginator totalMoneyOriginator;
        private int playerTotalMoneyCount;

        public TotalMoneyEditor()
        {
            stateHistory = new List<TotalMoneyMemento>();
            totalMoneyOriginator = new TotalMoneyOriginator();
            playerTotalMoneyCount = 0;
        }

        public void addMoney()
        {
            stateHistory.Add(totalMoneyOriginator.takeSnapshot());
        }

        public void undo()
        {
            totalMoneyOriginator.restore(stateHistory[stateHistory.Count - 1]);
            stateHistory.RemoveAt(stateHistory.Count - 1);
        }

        public int getCurrMoney()
        {
            return this.stateHistory[stateHistory.Count - 1].getSavedMoney();
        }

        public void AddTempMoney(int value)
        {
            this.totalMoneyOriginator.addMoney(value);
        }

        public int getCurrTempMoneyCount()
        {
            return this.totalMoneyOriginator.totalMoney;
        }
    }
}