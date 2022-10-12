
namespace Shared.Observer
{
    public abstract class ConcreateSubject :Subject
    {
        public ConcreateSubject() : base() { }

        public override void Update(string cords)
        {
           foreach(var obs in Observers)
            {
                obs.UpdateCords(cords);
            }
        }
    }
}