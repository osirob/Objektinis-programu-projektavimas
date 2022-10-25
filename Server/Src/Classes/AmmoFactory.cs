using Shared.Shared;

namespace Server.Src.Classes
{
    public static class AmmoFactory
    {
        public static AmmoPack CreateSmallAmmoPack(int xcoord, int ycoord, int id)
        {
            return new AmmoPack(25, xcoord, ycoord, id);
        }

        public static AmmoPack CreateMediumAmmoPack(int xcoord, int ycoord, int id)
        {
            return new AmmoPack(50, xcoord, ycoord, id);
        }

        public static AmmoPack CreateBigAmmoPack(int xcoord, int ycoord, int id)
        {
            return new AmmoPack(100, xcoord, ycoord, id);
        }
    }
}
