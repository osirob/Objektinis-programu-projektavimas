using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class AmmoFactory : ICollectableFactory
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

        public ICollectable CreateCollectable(int value, int xCoord, int yCoord, int id)
        {
            return new AmmoPack(50, xCoord, yCoord, id);
        }
    }
}
