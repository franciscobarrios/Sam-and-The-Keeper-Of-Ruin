using System.Collections.Generic;
using Interactable_Objects.Scripts;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public  List<InventorySlot> Container = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(ItemData item, int amount)
    {
        bool hasItem = false;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item)
            {
                Container[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(item, amount));
        }
    }

    public List<InventorySlot> GetItems()
    {
        return Container;
    }
}