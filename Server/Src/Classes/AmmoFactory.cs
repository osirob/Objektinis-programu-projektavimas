using Shared.Shared;

namespace Server.Src.Classes
{
    public static class AmmoFactory
    {
        public static AmmoPack CreateSmallAmmoPack(int xcoord)
        {
            return new AmmoPack(25, xcoord);
        }

        public static AmmoPack CreateMediumAmmoPack(int xcoord)
        {
            return new AmmoPack(50, xcoord);
        }

        public static AmmoPack CreateBigAmmoPack(int xcoord)
        {
            return new AmmoPack(100, xcoord);
        }
    }
}
