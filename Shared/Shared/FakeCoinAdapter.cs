using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    internal class FakeCoinAdapter : IFake
    {
        private Coin coin;
        public FakeCoinAdapter(Coin coin)
        {
            this.coin = coin;
        }
        public void isFake()
        {
            coin.Value = 0;
        }
    }
}
