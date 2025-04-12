using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Interactable_Objects.Scripts;
using NUnit.Framework.Interfaces;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private UIDocument inventoryUIDocument;
    private VisualElement _background;
    private VisualElement _inventoryContainer;
    private VisualElement _inventoryGrid;

    private VisualElement _itemImage;
    private Label _itemNameLabel;
    private Label _itemTypeLabel;
    private Label _itemDescriptionLabel;

    private void Start()
    {
        VisualElement root = inventoryUIDocument.rootVisualElement;
        _background = root.Q<VisualElement>("background");
        _inventoryContainer = root.Q<VisualElement>("inventory-container");
        _inventoryGrid = root.Q<VisualElement>("inventory-grid");

        _itemImage = root.Q<VisualElement>("item-image");
        _itemNameLabel = root.Q<Label>("item-name-lbl");
        _itemTypeLabel = root.Q<Label>("item-type-lbl");
        _itemDescriptionLabel = root.Q<Label>("item-description-lbl");

        if (InventoryHasItems())
        {
            PopulateInventoryGrid();
        }
    }

    public void ShowInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);

        if (inventoryCanvas.activeSelf && InventoryHasItems())
        {
            PopulateInventoryGrid();
        }
    }

    private void PopulateInventoryGrid()
    {
        _inventoryGrid.Clear();
        _itemImage.Clear();

        for (int i = 0; i < Inventory.instance.Items.Count; i++)
        {
            ItemData item = Inventory.instance.Items[i];
            VisualElement slot = CreateInventorySlot(item);
            _inventoryGrid.Add(slot);
        }
    }

    private VisualElement CreateInventorySlot(ItemData item)
    {
        VisualElement slot = new VisualElement();
        slot.AddToClassList("inventory-slot"); // Apply the USS class

        Image itemIcon = new Image();
        itemIcon.AddToClassList("item-icon");
        itemIcon.sprite = item.icon;
        slot.Add(itemIcon);

        Label itemQuantity = new Label();
        itemQuantity.AddToClassList("item-quantity");
        itemQuantity.text = item.isStackable ? item.quantity.ToString() : "";
        slot.Add(itemQuantity);

        slot.RegisterCallback<ClickEvent>((evt) => { DisplayItemDetails(item); });

        return slot;
    }

    private void DisplayItemDetails(ItemData item)
    {
        _itemImage.Clear();
        Image itemImage = new Image();
        itemImage.sprite = item.icon;
        _itemImage.Add(itemImage);
        _itemNameLabel.text = item.name;
        _itemTypeLabel.text = item.type.ToString();
        _itemDescriptionLabel.text = item.description;
    }

    private bool InventoryHasItems()
    {
        return (Inventory.instance.Items.Count > 0);
    }
}