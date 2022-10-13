
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

        public abstract void ReportAboutDeath(int id);
        public abstract void ReceiveAboutDeath(int id);
        
        public void Subscribe(Observer o)
        {
            Console.WriteLine("Subscribed");
            Observers.Add(o);
            o.SetSubject(this);
        }

        public void Unsubscribe(Observer o)
        {
            Observers.Remove(o);
        }
    }
}