
namespace Shared.Observer
{
    public abstract class Observer
    {
        private Subject subject;
        public abstract void UpdateCords(string cords);
    }
}