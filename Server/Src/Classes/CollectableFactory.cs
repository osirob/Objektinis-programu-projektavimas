using Server.Src.Interfaces;
using Shared.Shared;

namespace Server.Src.Classes
{
    public class CollectableFactory
    {
        public enum CollectableTypes
        {
            Coin, Armor
        }

        private Dictionary<CollectableTypes, ICollectableFactory> factories =
            new Dictionary<CollectableTypes, ICollectableFactory>();

        public CollectableFactory()
        {
            foreach(CollectableTypes type in Enum.GetValues(typeof(CollectableTypes)))
            {
                var factory = (ICollectableFactory)Activator.CreateInstance(Type.GetType("Server.Src.Classes." + Enum.GetName(typeof(CollectableTypes), type) + "Factory"));
                factories.Add(type, factory);
            }
        }

        public ICollectable MakeCollectable(CollectableTypes type, int value, int xCoord)
        {
            return factories[type].CreateCollectable(value, xCoord);
        }
    }
}
