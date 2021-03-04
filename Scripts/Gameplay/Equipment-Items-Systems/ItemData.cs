using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Inventory.UI;

namespace IND.Gameplay.Items
{
    [CreateAssetMenu(fileName = "Item Base Class", menuName = "IND/Gameplay/Items/Item Base Class")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public GameObject modelPrefab;
        public Sprite inventoryIcon;
        public InventorySlotType_UI inventorySlotType;

        public int maxStackAmount = 1; //1 equals not stackable. Refers to the maxStackAmount

        [Multiline()]
        public string tooltipContent;
    }
}