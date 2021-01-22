using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Gameplay.Items;

namespace IND.Gameplay.Inventory.UI
{
    /// <summary>A Class that executes all Inventory UI Logic</summary>
    public static class Inventory_UI_Static
    {
        /// <summary>Default Color for all inventory slots that have an no equipped item</summary>
        public static Color emptyIconColor;

        public static Color isBeingDraggedColor = new Color(1f, 1f, 1f, 0.2f);

        /// <summary>Default Color for all inventory slots that have an Item equipped in them</summary>
        public static Color assignedIconColor = new Color(1f, 1f, 1f, 1f);

        /// <summary>Used to fade the left hand item slot when a two handed weapon is equipped</summary>
        public static Color twoHandedItemFadedColor = new Color(1f, 1f, 1f, 0.35f);

        public static Sprite bgBackpackIcon;
        public static Sprite bgWeaponIcon;
        public static Sprite bgHeadIcon;
        public static Sprite bgBodyIcon;

        /// <summary>Called When an Item is Dragged on a slot</summary>
        public static void OnItemDraggedOnSlot(InventorySlot_UI originalSlot, InventorySlot_UI targetSlot, PartyCharacterInventory characterInventory = null, PartyCampInventory campInventory = null)
        {
            if (originalSlot == null || targetSlot == null)
            {
                return;
            }

            if (originalSlot == targetSlot)
                return;

            Item originalItem = originalSlot.assignedItem;
            Item targetItem = targetSlot.assignedItem;

            if (IsSlotCompatible(targetSlot, originalSlot.assignedItem) == true) //Can We place the item in the target slot
            {
                if (originalSlot.assignedItem.itemData.inventorySlotType == InventorySlotType_UI.weapon && targetSlot.slotType == InventorySlotType_UI.weapon) //Is Weapon Class 
                {
                    OnDraggedOnWeaponSlot(originalSlot, targetSlot); //Excute Special On Drag Logic For Weapon Slot
                }
                else
                {
                    if (targetSlot.assignedItem != null && targetSlot.assignedItem.itemData != null) //Is there already an item in the slot?
                    {
                        //Is Item Stackable?
                        if (originalItem.itemData == targetItem.itemData && originalItem.itemData.maxStackAmount > 1)
                        {
                            MergeItems(originalSlot, targetSlot);
                        }
                        else
                        {
                            SwapItemSlots(originalSlot, targetSlot, characterInventory); // There is an existing Item here we will swap them around
                        }
                    }
                    else //No Item Exists in Target slot
                    {
                        RemoveItemFromSlot(originalSlot, targetSlot);
                        AssignItemToEmptySlot(targetSlot, originalItem, originalSlot.slotOwnerType, originalSlot.itemInventoryIndex, characterInventory, campInventory);
                    }
                }
            }
            else
            {
                CancelItemDragging(originalSlot); //Cancels the current item drag restoring it to its previous location
            }
        }
       
        /// <summary>Bool to see if our current item can be dropped on the target slot</summary>
        private static bool IsSlotCompatible(InventorySlot_UI targetSlot, Item itemClass)
        {
            switch (targetSlot.slotType)
            {
                case InventorySlotType_UI.backpack:
                    return true;
                case InventorySlotType_UI.head:
                    if (itemClass.itemData.inventorySlotType == InventorySlotType_UI.head)
                    {
                        return true;
                    }
                    break;
                case InventorySlotType_UI.body:
                    if (itemClass.itemData.inventorySlotType == InventorySlotType_UI.body)
                    {
                        return true;
                    }
                    break;
                case InventorySlotType_UI.weapon:
                    if (itemClass.itemData.inventorySlotType == InventorySlotType_UI.weapon)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>Executed When the User Drags a weapon onto a weapon slot</summary>
        private static void OnDraggedOnWeaponSlot(InventorySlot_UI originalSlot, InventorySlot_UI targetSlot)
        {
            WeaponItemData weaponData = originalSlot.assignedItem.itemData as WeaponItemData;
            switch (weaponData.handlingType)
            {
                case WeaponHandlingType.OneHanded:
                    AssignWeaponToWeaponSlot(targetSlot, false, originalSlot);
                    break;
                case WeaponHandlingType.TwoHanded:
                    AssignWeaponToWeaponSlot(targetSlot, true, originalSlot);
                    break;
            }
        }

        /// <summary>Assings an Item to an empty slot that has no existing content</summary>
        public static void AssignItemToEmptySlot(InventorySlot_UI targetSlot, Item itemClass, InventorySlotOwnerType_UI originalSlotOwner, int itemIndex, PartyCharacterInventory characterInventory = null, PartyCampInventory campInventory = null)
        {
            if (targetSlot == null)
            {
                Debug.LogError("Empty Slot Target");
                return;
            }

            targetSlot.assignedItem = itemClass;
            targetSlot.bgIcon.sprite = itemClass.itemData.inventoryIcon;
            targetSlot.bgIcon.color = assignedIconColor;
            targetSlot.itemInventoryIndex = itemIndex;

            UpdateItemStackCount(targetSlot);
            UpdateItemInventoryOwner(itemClass, originalSlotOwner, targetSlot, itemIndex);

            //Let The Slot Know a new item was added to it
            targetSlot.OnItemAddedToSlot();
        }

        /// <summary>If the item is stackable we will update the items text and display it</summary>
        private static void UpdateItemStackCount(InventorySlot_UI slot)
        {
            if (slot.assignedItem.currentStackAmount > 1)
            {
                slot.stackAmountText.gameObject.SetActive(true);
                slot.stackAmountText.text = slot.assignedItem.currentStackAmount.ToString();
            }
            else
            {
                slot.stackAmountText.gameObject.SetActive(false);
            }
        }

        /// <summary>If the item is moved from one Inventory type to another, e.g. from pawn to party</summary>
        private static void UpdateItemInventoryOwner(Item itemClass, InventorySlotOwnerType_UI originalSlotOwner, InventorySlot_UI targetSlot, int itemIndex)
        {
            if (originalSlotOwner != targetSlot.slotOwnerType) //Changing From Party To Character to Party or Vice Versa
            {
                switch (targetSlot.slotOwnerType)
                {
                    case InventorySlotOwnerType_UI.Character:
                        PartyCharacterInventory characterInventory = targetSlot.GetComponentInParent<InventoryPawn_UI>().characterInventory;
                        switch (targetSlot.slotType)
                        {
                            case InventorySlotType_UI.backpack:
                                characterInventory.AssignItemToBackpack(itemClass, targetSlot.slotNumberInList, true);
                                targetSlot.itemInventoryIndex = characterInventory.beltItems.Count - 1;
                                break;
                            case InventorySlotType_UI.head:
                                characterInventory.AssignHeadEquipmentItem(itemClass);
                                break;
                            case InventorySlotType_UI.body:
                                characterInventory.AssignBodyEquipmentItem(itemClass);
                                break;
                            case InventorySlotType_UI.weapon:
                                if (targetSlot.slotNumberInList == -1)
                                {
                                    characterInventory.AssignLeftHandWeaponItem(itemClass);
                                }
                                else
                                {
                                    characterInventory.AssignRightHandWeaponItem(itemClass);
                                }
                                break;
                        }
                        break;
                    case InventorySlotOwnerType_UI.Party:
                        PartyCampInventory campInventory = CampInventoryManager_UI.singleton.partyCampInventory;
                        campInventory.AssignItem(targetSlot, 0, itemClass);
                        break;
                }
            }
            else
            {
                switch (targetSlot.slotOwnerType)
                {
                    case InventorySlotOwnerType_UI.Character:
                        PartyCharacterInventory characterInventory = targetSlot.GetComponentInParent<InventoryPawn_UI>().characterInventory;
                        switch (targetSlot.slotType)
                        {
                            case InventorySlotType_UI.backpack:
                                characterInventory.AssignItemToBackpack(itemClass, targetSlot.slotNumberInList, false);
                                break;
                            case InventorySlotType_UI.head:
                                characterInventory.AssignHeadEquipmentItem(itemClass);
                                break;
                            case InventorySlotType_UI.body:
                                characterInventory.AssignBodyEquipmentItem(itemClass);
                                break;
                            case InventorySlotType_UI.weapon:
                                if (targetSlot.slotNumberInList == -1)
                                {
                                    characterInventory.AssignLeftHandWeaponItem(itemClass);
                                }
                                else
                                {
                                    characterInventory.AssignRightHandWeaponItem(itemClass);
                                }
                                break;
                        }
                        break;
                    case InventorySlotOwnerType_UI.Party:
                        PartyCampInventory campInventory = CampInventoryManager_UI.singleton.partyCampInventory;
                        campInventory.AssignItem(targetSlot, itemIndex);
                        break;
                }

            }
        }

        /// <summary>Used To Clear all data from a slot resetting it empty</summary>
        public static void ClearUISlot(InventorySlot_UI slot)
        {
            slot.bgIcon.color = emptyIconColor;
            slot.stackAmountText.gameObject.SetActive(false);
            slot.assignedItem = null;
            slot.itemInventoryIndex = 0;

            switch (slot.slotType)
            {
                case InventorySlotType_UI.backpack:
                    slot.bgIcon.sprite = bgBackpackIcon;
                    break;
                case InventorySlotType_UI.head:
                    slot.bgIcon.sprite = bgHeadIcon;
                    break;
                case InventorySlotType_UI.body:
                    slot.bgIcon.sprite = bgBodyIcon;
                    break;
                case InventorySlotType_UI.weapon:
                    slot.bgIcon.sprite = bgWeaponIcon;
                    break;
            }
        }

        /// <summary>Called to Remove the Item From The Slot, Will Automatically call the ClearUISlot Function</summary>
        public static void RemoveItemFromSlot(InventorySlot_UI originalSlot, InventorySlot_UI targetSlot = null)
        {
            if (originalSlot.assignedItem.itemData == null)
                return;

            originalSlot.OnItemRemovedFromSlot();

            switch (originalSlot.slotOwnerType)
            {
                case InventorySlotOwnerType_UI.Character:
                    InventoryPawn_UI pawnInventory = originalSlot.GetComponentInParent<InventoryPawn_UI>();
                    RemoveItemFromCharacter(originalSlot, pawnInventory.characterInventory);
                    break;
                case InventorySlotOwnerType_UI.Party:
                    CampInventoryManager_UI.singleton.partyCampInventory.RemoveItem(originalSlot);
                    break;
            }

            ClearUISlot(originalSlot);
        }

        /// <summary>If the Item Belongs to a characters Inventory We will remove it from that characters inventory</summary>
        private static void RemoveItemFromCharacter(InventorySlot_UI slot, PartyCharacterInventory characterInventory)
        {
            switch (slot.slotType)
            {
                case InventorySlotType_UI.backpack:
                    characterInventory.RemoveItemFromBackpack(slot.itemInventoryIndex);

                    //Update All Items In Backpack
                    UpdateAllCharacterInventoryBeltItemIndexs(slot.GetComponentInParent<InventoryPawn_UI>(), characterInventory);

                    break;
                case InventorySlotType_UI.head:
                    characterInventory.RemoveHeadEquipment();
                    break;
                case InventorySlotType_UI.body:
                    characterInventory.RemoveBodyEquipment();
                    break;
                case InventorySlotType_UI.weapon:
                    WeaponItemData weaponItemData = slot.assignedItem.itemData as WeaponItemData;
                    switch (weaponItemData.handlingType)
                    {
                        case WeaponHandlingType.OneHanded:
                            if (slot.slotNumberInList == -1)
                            {
                                characterInventory.RemoveLeftHandWeapon();
                            }
                            else
                            {
                                characterInventory.RemoveRightHandWeapon();
                            }
                            break;
                        case WeaponHandlingType.TwoHanded:
                            RemoveItemFromSlot(slot.GetComponentInParent<InventoryPawn_UI>().leftHandSlot);
                            RemoveItemFromSlot(slot.GetComponentInParent<InventoryPawn_UI>().rightHandSlot);
                            characterInventory.RemoveLeftHandWeapon();
                            characterInventory.RemoveRightHandWeapon();
                            break;
                    }
                    break;
            }
        }

        /// <summary>Swaps One Slots Items with another and vice versa</summary>
        public static void SwapItemSlots(InventorySlot_UI originalSlot, InventorySlot_UI targetSlot, PartyCharacterInventory characterInventory)
        {
            Item originalItem = originalSlot.assignedItem;
            Item targetItem = targetSlot.assignedItem;

            AssignItemToEmptySlot(targetSlot, originalItem, originalSlot.slotOwnerType, originalSlot.itemInventoryIndex, characterInventory);
            AssignItemToEmptySlot(originalSlot, targetItem, originalSlot.slotOwnerType, targetSlot.itemInventoryIndex, characterInventory);
        }

        /// <summary>Items can be stacked so we will add the original item that was dragged onto the target items stack amount</summary>
        public static void MergeItems(InventorySlot_UI originalSlot, InventorySlot_UI targetSlot)
        {
            int amountToIncreaseTargetStackBy = targetSlot.assignedItem.currentStackAmount + originalSlot.assignedItem.currentStackAmount;

            if (amountToIncreaseTargetStackBy > targetSlot.assignedItem.itemData.maxStackAmount)
            {
                amountToIncreaseTargetStackBy = targetSlot.assignedItem.itemData.maxStackAmount - targetSlot.assignedItem.currentStackAmount;
            }
            else
            {
                amountToIncreaseTargetStackBy = originalSlot.assignedItem.currentStackAmount;
            }

            originalSlot.assignedItem.currentStackAmount -= amountToIncreaseTargetStackBy;
            targetSlot.assignedItem.currentStackAmount += amountToIncreaseTargetStackBy;
            if (targetSlot.assignedItem.currentStackAmount > 1)
            {
                originalSlot.stackAmountText.gameObject.SetActive(true);
            }
            targetSlot.stackAmountText.text = targetSlot.assignedItem.currentStackAmount.ToString();

            if (originalSlot.assignedItem.currentStackAmount == 0) //No Stack Available Delete item
            {
                RemoveItemFromSlot(originalSlot);

                //Update All Camp Item Index Numbers Due To Merge
                PartyCampInventory inventory = CampInventoryManager_UI.singleton.partyCampInventory;
                CampInventoryManager_UI camp = CampInventoryManager_UI.singleton;

                for (int i = 0; i < camp.slots.Count; i++)
                {
                    for (int g = 0; g < inventory.partyInventoryItems.Count; g++)
                    {
                        if (inventory.partyInventoryItems[g] == camp.slots[i].assignedItem)
                        {
                            camp.slots[i].itemInventoryIndex = g;
                        }
                    }
                }
            }
            else //Update Previous stack after taken away
            {
                originalSlot.stackAmountText.text = originalSlot.assignedItem.currentStackAmount.ToString();
                if (originalSlot.assignedItem.currentStackAmount == 1)
                {
                    originalSlot.stackAmountText.gameObject.SetActive(false);
                }
                originalSlot.bgIcon.color = assignedIconColor;
            }
        }

        /// <summary>Extra Functionality called when adding an item to a weapon slot, used for working with one handed and two handed items, e.g. removing both one handed items from left and right if a two handed weapon is added</summary>
        public static void AssignWeaponToWeaponSlot(InventorySlot_UI targetSlot, bool isTwoHandedWeapon, InventorySlot_UI originalSlot = null)
        {
            InventoryPawn_UI pawnInventory = targetSlot.GetComponentInParent<InventoryPawn_UI>();
            InventorySlot_UI rhHandSlot = pawnInventory.rightHandSlot;
            InventorySlot_UI lhHandSlot = pawnInventory.leftHandSlot;
            Item originalSlotItem = originalSlot.assignedItem;

            if (originalSlot != null)
            {
                RemoveItemFromSlot(originalSlot);
            }

            if (isTwoHandedWeapon == true)
            {
                //Check Do Both Slots Have and add existing item to inventory
                if (rhHandSlot.assignedItem != null)
                {
                    if (rhHandSlot.assignedItem.itemData != null)
                    {
                        rhHandSlot.OnItemRemovedFromSlot();
                        if (originalSlot.assignedItem == null) //If the slot that we swapped from is empty we will place the item there
                        {
                            AssignItemToEmptySlot(originalSlot, rhHandSlot.assignedItem, InventorySlotOwnerType_UI.Character, 0);
                        }
                        else //If not we will fetch an empty slot in the belt to add too 
                        {
                            AddItemToEmptyBeltSlot(rhHandSlot.assignedItem, pawnInventory);
                        }
                    }
                }
                if (lhHandSlot.assignedItem != null)
                {
                    if (originalSlot.assignedItem.itemData == null)
                    {
                        AssignItemToEmptySlot(originalSlot, lhHandSlot.assignedItem, InventorySlotOwnerType_UI.Character, 0);
                    }
                    else
                    {
                        AddItemToEmptyBeltSlot(lhHandSlot.assignedItem, pawnInventory);
                    }
                }


                rhHandSlot.assignedItem = originalSlotItem;
                rhHandSlot.bgIcon.sprite = originalSlotItem.itemData.inventoryIcon;
                rhHandSlot.bgIcon.color = assignedIconColor;
                rhHandSlot.itemInventoryIndex = 0;

                lhHandSlot.assignedItem = originalSlotItem;
                lhHandSlot.bgIcon.sprite = originalSlotItem.itemData.inventoryIcon;
                lhHandSlot.bgIcon.color = twoHandedItemFadedColor;
                lhHandSlot.itemInventoryIndex = 0;

                pawnInventory.characterInventory.rightHandWeaponItem = originalSlotItem;
                pawnInventory.characterInventory.leftHandWeaponItem = originalSlotItem;
            }
            else
            {
                if (rhHandSlot.assignedItem != null)
                {
                    //If Current 
                    if (rhHandSlot.assignedItem.itemData != null)
                    {
                        //Check Is Current Item Two Handed
                        WeaponItemData weaponData = rhHandSlot.assignedItem.itemData as WeaponItemData;
                        if (weaponData.handlingType == WeaponHandlingType.TwoHanded)
                        {
                            AssignItemToEmptySlot(originalSlot, rhHandSlot.assignedItem, InventorySlotOwnerType_UI.Character, 0);
                            AddItemToEmptyBeltSlot(lhHandSlot.assignedItem, pawnInventory);

                            RemoveItemFromSlot(lhHandSlot);
                            RemoveItemFromSlot(rhHandSlot);
                            pawnInventory.characterInventory.rightHandWeaponItem = null;
                            pawnInventory.characterInventory.leftHandWeaponItem = null;
                        }
                    }
                }
                if (targetSlot == rhHandSlot)
                {
                    rhHandSlot.assignedItem = originalSlotItem;
                    rhHandSlot.bgIcon.sprite = originalSlotItem.itemData.inventoryIcon;
                    rhHandSlot.bgIcon.color = assignedIconColor;
                    rhHandSlot.itemInventoryIndex = 0;
                    pawnInventory.characterInventory.rightHandWeaponItem = originalSlotItem;
                }
                else //is Left Hand Slot Instead
                {
                    lhHandSlot.assignedItem = originalSlotItem;
                    lhHandSlot.bgIcon.sprite = originalSlotItem.itemData.inventoryIcon;
                    lhHandSlot.bgIcon.color = assignedIconColor;
                    lhHandSlot.itemInventoryIndex = 0;
                    pawnInventory.characterInventory.leftHandWeaponItem = originalSlotItem;
                }
            }

            targetSlot.OnItemAddedToSlot();
        }

        /// <summary>Automatically Find an Empty Belt Slot in the pawns inventory and add the item to it</summary>
        private static void AddItemToEmptyBeltSlot(Item itemClass, InventoryPawn_UI pawnInventory)
        {
            for (int i = 0; i < pawnInventory.beltSlots.Count; i++)
            {
                if (pawnInventory.beltSlots[i].assignedItem == null)
                {
                    AssignItemToEmptySlot(pawnInventory.beltSlots[i], itemClass, InventorySlotOwnerType_UI.Character, 0);
                    break;
                }
            }
        }

        /// <summary>Can be called to immediately cancel the users currently dragged item, will restore the item to its original slot and state</summary>
        public static void CancelItemDragging(InventorySlot_UI slot)
        {
            InventoryManager_UI.draggableItem.DisableDragItem();
        }

        /// <summary>Updates all items in the belt slots of a character to make sure they have the right correct index references after adjusting items in the belt</summary>
        private static void UpdateAllCharacterInventoryBeltItemIndexs(InventoryPawn_UI pawnInventory, PartyCharacterInventory characterInventory)
        {
            for (int i = 0; i < pawnInventory.beltSlots.Count; i++)
            {
                if (pawnInventory.beltSlots[i].assignedItem != null)
                {
                    if (pawnInventory.beltSlots[i].assignedItem.itemData != null)
                    {
                        for (int g = 0; g < characterInventory.beltItems.Count; g++)
                        {
                            if (characterInventory.beltItems[g].inventorySlotIndex == pawnInventory.beltSlots[i].slotNumberInList) //Update This Item
                            {
                                pawnInventory.beltSlots[i].itemInventoryIndex = g;
                            }
                        }
                    }
                }
            }
        }
    }
}