using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class ArmorFactory : ICollectableFactory
    {
        public ICollectable CreateCollectable(int value, int xCoord, int yCoord, int id)
        {
            return new Armor(value, xCoord, yCoord, id);
        }
    }
}
