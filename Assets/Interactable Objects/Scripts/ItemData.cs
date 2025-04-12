using UnityEngine;

namespace Interactable_Objects.Scripts
{
    public abstract class ItemData : ScriptableObject
    {
        public GameObject itemPrefab;
        public new string name;
        public ItemDataType type;
        [TextArea(3, 10)]
        public string description;
        public Sprite icon;
        public bool isStackable;
        public int quantity;
    }
}