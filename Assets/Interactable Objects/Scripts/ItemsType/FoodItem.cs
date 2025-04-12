using System;
using UnityEngine;

namespace Interactable_Objects.Scripts.ItemsType
{
    [CreateAssetMenu(fileName = "New Food Item", menuName = "Inventory System/Items/Food Item", order = 4)]
    public class FoodItem : ItemData
    {
        public int healAmount;
        public bool isPoisonous;

        private void Awake()
        {
            type = ItemDataType.Food;
        }
        
        public void OnEat()
        {
            // Implement consumption logic here.
            Debug.Log($"Consumed {name}, healed {healAmount}");
        }
    }
}