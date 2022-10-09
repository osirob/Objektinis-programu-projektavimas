using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void UpdateCord()
        {
            foreach(Observer observer in observers)
            {
                observer.UpdateCordinatesFirstPlayer("Test");
            }
        }

        public abstract void SendCordinates(string cordinates, string PlayerNumber);
        public abstract void ReceiveCordinates(string cordinates, string PlayerNumber);
    }
}
