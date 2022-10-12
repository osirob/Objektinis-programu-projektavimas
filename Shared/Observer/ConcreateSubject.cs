
namespace Server.Observer
{
    public abstract class ConcreateSubject :Subject
    {
        public ConcreateSubject() : base() { }

        public override void Update()
        {
           foreach(var obs in Observers)
            {
                obs.Update();
            }
        }
    }
}