using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using UnityEngine.UI;
using IND.Gameplay.Items;

namespace IND.Gameplay.Inventory.UI
{
    /// <summary>Handles the current inventory item that the user is dragging from one slot to another</summary>
    public class InventoryDraggableItem_UI : IND_Mono
    {
        public Item item;
        private InventorySlot_UI itemSlot;
        [SerializeField] protected Image slotIcon;
        public RectTransform rect;
        public RectTransform parentRect;

        /// <summary>Begin the dragging of the inventory item</summary>
        public void ActivateDragItem(Item itemController, InventorySlot_UI originalItemSlot)
        {
            gameObject.SetActive(true);
            item = itemController;
            itemSlot = originalItemSlot;
            itemSlot.bgIcon.color = Inventory_UI_Static.isBeingDraggedColor;
            slotIcon.sprite = item.itemData.inventoryIcon;
        }

        /// <summary>Stops dragging the current item</summary>
        public void DisableDragItem()
        {
            gameObject.SetActive(false);
            if(itemSlot != null)
            {
                if (itemSlot.assignedItem != null)
                {
                    itemSlot.bgIcon.color = Inventory_UI_Static.assignedIconColor;
                }
                else
                {
                    itemSlot.bgIcon.color = Inventory_UI_Static.emptyIconColor;
                }
                itemSlot = null;
            }
            item = null;
        }
    }
}