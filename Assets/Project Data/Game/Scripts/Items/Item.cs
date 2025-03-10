using UnityEngine;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "Item", menuName = "Content/Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] Type itemType;
        public Type ItemType => itemType;

        [Space]
        [SerializeField] Sprite icon;
        public Sprite Icon => icon;
        
        [SerializeField] Sprite iconOnBuildings;
        public Sprite IconOnBuildings => iconOnBuildings;

        [SerializeField] GameObject model;
        public GameObject Model => model;

        [SerializeField] float modelHeight;
        public float ModelHeight => modelHeight;

        private Pool pool;
        public Pool Pool => pool;

        public void Initialise()
        {
            pool = new Pool(new PoolSettings(model.name, model, 0, true));
        }

        public enum Type
        {
            None = -1,
            Soap = 0,
            Injection = 1,
            Pill = 2
        }
    }
}