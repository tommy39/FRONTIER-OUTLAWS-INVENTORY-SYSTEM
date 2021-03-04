using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using UnityEngine.UI;
using IND.Gameplay.Items;
using UnityEngine.EventSystems;
using TMPro;
using IND.Core.Cameras;
using IND.Core.Tooltips;

namespace IND.Gameplay.Inventory.UI
{
    public class InventorySlot_UI : IND_Mono, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public InventorySlotType_UI slotType;
        public InventorySlotOwnerType_UI slotOwnerType;
        public Image bgIcon;
        public int slotNumberInList;
        public int itemInventoryIndex = 0;
        [ShowIf("assignedItem")] public Item assignedItem;
        public TextMeshProUGUI stackAmountText;

        public override void Init()
        {
            stackAmountText.gameObject.SetActive(false);
        }

        /// <summary>Virtual Function That is called every time an Item is added to a slot</summary>
        public virtual void OnItemAddedToSlot()
        {

        }

        /// <summary>Virtual Function That is called every time an Item is removed from a slot</summary>
        public virtual void OnItemRemovedFromSlot()
        {

        }

        #region Unity Events

        public void OnPointerDown(PointerEventData eventData)
        {
            if (assignedItem == null)
                return;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (assignedItem == null)
                return;

            Vector2 anchoredPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(InventoryManager_UI.draggableItem.parentRect, Input.mousePosition, InventoryManager_UI.canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : CameraManager.singleton.activeCamera, out anchoredPos);
            InventoryManager_UI.draggableItem.rect.anchoredPosition = anchoredPos;

            InventoryManager_UI.draggableItem.ActivateDragItem(assignedItem, this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (assignedItem == null)
                return;

            InventoryManager_UI.draggableItem.rect.anchoredPosition += eventData.delta / InventoryManager_UI.canvas.scaleFactor;

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (assignedItem == null)
                return;

            InventoryManager_UI.draggableItem.DisableDragItem();

        }

        public void OnDrop(PointerEventData eventData)
        {
            if (InventoryManager_UI.draggableItem.item == null)
                return;

            InventoryManager_UI.draggableItem.DisableDragItem();

            if (eventData.pointerDrag != null)
            {
                InventorySlot_UI draggedItem = eventData.pointerDrag.GetComponent<InventorySlot_UI>();
                if (draggedItem == null) //Not Dragged On an Item Slot
                    return;

                switch (slotOwnerType)
                {
                    case InventorySlotOwnerType_UI.Character:
                        Inventory_UI_Static.OnItemDraggedOnSlot(draggedItem, this, GetComponentInParent<InventoryPawn_UI>().characterInventory);
                        break;
                    case InventorySlotOwnerType_UI.Party:
                        Inventory_UI_Static.OnItemDraggedOnSlot(draggedItem, this, null, GetComponentInParent<CampInventoryManager_UI>().partyCampInventory);
                        break;
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (assignedItem != null)
            {
                if (assignedItem.itemData != null)
                {
                    TooltipManager.delay = LeanTween.delayedCall(0.5f, () =>
                    {
                        TooltipManager.Show(assignedItem.itemData.tooltipContent, "");
                    });
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (assignedItem != null)
            {
                if (assignedItem.itemData != null)
                {
                    LeanTween.cancel(TooltipManager.delay.uniqueId);
                    TooltipManager.Hide();
                }
            }
        }
        #endregion
    }
}