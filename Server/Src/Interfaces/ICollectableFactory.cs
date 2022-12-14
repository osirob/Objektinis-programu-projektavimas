using Shared.Shared;

namespace Server.Src.Interfaces
{
    public interface ICollectableFactory
    {
        ICollectable CreateCollectable(int value, int xCoord, int yCoord, int id);
    }
}
