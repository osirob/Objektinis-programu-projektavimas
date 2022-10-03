﻿using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class CoinFactory : ICollectableFactory
    {
        public ICollectable CreateCollectable(int value, int xCoord)
        {
            return new Coin(value, xCoord);
        }
    }
}
