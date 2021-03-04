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
    public class PartyCharacterInventory
    {
        public GameObject characterModelBasePrefab;
        public Item rightHandWeaponItem;
        public Item leftHandWeaponItem;
        public Item bodyEquipmentItem;
        public Item headEquipmentItem;
        public List<Item> beltItems = new List<Item>();

        public void AssignItemToBackpack(Item item, int slotIndex, bool addItemToInventory)
        {
            if (addItemToInventory == true) //When New Equipment is being added (avoids error when starting with equipment on game start)
            {
                beltItems.Add(item);
            }

            item.inventorySlotIndex = slotIndex;
        }

        public void AssignHeadEquipmentItem(Item item)
        {
            headEquipmentItem = item;
        }

        public void AssignBodyEquipmentItem(Item item)
        {
            bodyEquipmentItem = item;
        }

        public void AssignLeftHandWeaponItem(Item item)
        {
            leftHandWeaponItem = item;
        }
        public void AssignRightHandWeaponItem(Item item)
        {
            rightHandWeaponItem = item;
        }

        public void RemoveItemFromBackpack(int itemIndex)
        {
            beltItems.RemoveAt(itemIndex);
        }

        public void RemoveHeadEquipment()
        {
            headEquipmentItem = null;
        }

        public void RemoveBodyEquipment()
        {
            bodyEquipmentItem = null;
        }

        public void RemoveLeftHandWeapon()
        {
            leftHandWeaponItem = null;
        }
        
        public void RemoveRightHandWeapon()
        {
            rightHandWeaponItem = null;
        }
    
    }


}