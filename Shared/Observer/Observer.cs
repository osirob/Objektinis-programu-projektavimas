
namespace Shared.Observer
{
    public abstract class Observer
    {
       protected Subject subject;

       public abstract void ReportAboutDeath(int id);

       public Subject GetSubject()
        {
            return subject;
        }

        public void SetSubject(Subject subject)
        {
            this.subject = subject;
        }
    }
}