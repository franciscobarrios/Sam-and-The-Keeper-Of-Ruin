using UnityEngine;

namespace Interactable_Objects.Scripts.ItemsType
{
    [CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable Item", order = 2)]
    public class ConsumableItem : ItemData
    {
        public int healAmount;
        public bool isPoisonous;

        public void Awake()
        {
            type = ItemDataType.Consumable;
        }

        public void OnConsume()
        {
            // Implement consumption logic here.
            Debug.Log($"Consumed {name}, healed {healAmount}");
        }
    }
}