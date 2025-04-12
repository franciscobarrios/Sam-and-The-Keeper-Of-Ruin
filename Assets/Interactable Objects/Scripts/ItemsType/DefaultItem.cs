using UnityEngine;

namespace Interactable_Objects.Scripts.ItemsType
{
    [CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Items/Default Item", order = 1)]
    public class DefaultItem : ItemData
    {
        public void Awake()
        {
            type = ItemDataType.Default;
        }
    }
}