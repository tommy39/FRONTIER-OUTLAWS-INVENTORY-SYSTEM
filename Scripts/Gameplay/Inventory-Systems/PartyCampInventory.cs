using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Items;
using IND.Gameplay.Inventory.UI;

namespace IND.Gameplay.Inventory
{
    [System.Serializable]
    public class PartyCampInventory
    {
        public List<Item> partyInventoryItems = new List<Item>();

        public void AssignItem(InventorySlot_UI slot, int itemIndex, Item item = null)
        {
            if (item != null)
            {
                partyInventoryItems.Add(item);
                item.inventorySlotIndex = slot.slotNumberInList;
                slot.itemInventoryIndex = partyInventoryItems.Count - 1;
            }
            else
            {
                partyInventoryItems[itemIndex].inventorySlotIndex = slot.slotNumberInList;

            }
        }

        public void RemoveItem(InventorySlot_UI slot)
        {
            partyInventoryItems.Remove(partyInventoryItems[slot.itemInventoryIndex]);
        }
    }
}