using System.Collections.Generic;
using Interactable_Objects.Scripts;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField]
    public Dictionary<int, ItemData> Items = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }


    public void AddItem(ItemData item, int quantity)
    {
        if (Items.ContainsKey(item.id)) // Assuming ItemData has an itemID
        {
            Items[item.id].quantity += quantity; // Add to existing quantity
        }
        else
        {
            ItemData newItem = Instantiate(item); // Create a new instance in the inventory
            newItem.quantity = quantity;
            Items.Add(newItem.id, newItem); // Add the item
        }
    }

    public void RemoveItem(ItemData item, int quantity)
    {
        if (Items.ContainsKey(item.id))
        {
            Items[item.id].quantity -= quantity;
            if (Items[item.id].quantity <= 0)
            {
                Items.Remove(item.id); // Remove if quantity is zero
            }
        }
    }

    public bool HasItem(ItemData item, int quantity)
    {
        return Items.ContainsKey(item.id) && Items[item.id].quantity >= quantity;
    }
}