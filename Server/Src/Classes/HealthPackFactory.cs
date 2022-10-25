using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class HealthPackFactory : ICollectableFactory
    {
        public ICollectable CreateCollectable(int value, int xCoord, int yCoord, int id)
        {
            return new HealthPack(value, xCoord, yCoord, id);
        }
    }
}
