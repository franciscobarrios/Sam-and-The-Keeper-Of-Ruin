using Interactable_Objects.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Slot", menuName = "Inventory System/Items/Inventory Slot", order = 5)]
public class InventorySlot : ScriptableObject
{
    public ItemData item;
    public int amount;

    public InventorySlot(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}