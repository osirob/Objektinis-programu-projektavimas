
namespace Shared.Observer
{
    public class ConcreateSubject :Subject
    {
       
        public override void ReportAboutDeath(int id)
        {
           foreach(var obs in Observers)
            { 
                obs.ReportAboutDeath(id);
            }
        }

        public override void ReceiveAboutDeath(int id)
        {
            Console.WriteLine("Receive info about one of players death");
            this.ReportAboutDeath(id);
        }
    }
}