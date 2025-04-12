using UnityEngine;

namespace Interactable_Objects.Scripts.ItemsType
{
    [CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment Item", order = 3)]
    public class EquipmentItem : ItemData
    {
        public int damageAmount;

        private void Awake()
        {
            type = ItemDataType.Equipable;
        }

        public void OnEquip()
        {
            // Implement consumption logic here.
            Debug.Log($"Equip {name}, damage {damageAmount}");
        }
    }
}