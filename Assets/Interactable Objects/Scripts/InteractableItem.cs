using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public InventorySlot inventorySlot;

    public void Pickup(Inventory inventory)
    {
        inventory.AddItem(inventorySlot.item, inventorySlot.amount);
        Destroy(gameObject);
    }
}