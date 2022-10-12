
namespace Shared.Observer
{
    public abstract class Subject
    {
        protected List<Observer> Observers;

        protected Subject()
        {
            Observers = new List<Observer>();
        }

        protected Subject(List<Observer> observers)
        {
            Observers = observers;
        }

        public abstract void Update(string cords);
        public abstract void Subscribe(Observer observer);
        public abstract void Unsubscribe(Observer observer);
    }
}