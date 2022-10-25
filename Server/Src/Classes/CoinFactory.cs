using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class CoinFactory : ICollectableFactory
    {
        public ICollectable CreateCollectable(int value, int xCoord, int yCoord, int id)
        {
            return new Coin(value, xCoord, yCoord, id);
        }
    }
}
