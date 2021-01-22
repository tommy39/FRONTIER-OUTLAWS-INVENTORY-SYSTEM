using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Items;

namespace IND.Gameplay.Inventory.UI
{
    public class InventorySlot_Weapon_UI : InventorySlot_UI
    {
        public override void OnItemAddedToSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            WeaponItemData weaponItem = assignedItem.itemData as WeaponItemData;
            switch (weaponItem.handlingType)
            {
                case WeaponHandlingType.OneHanded:
                    if (slotNumberInList == -1)//Left Hand
                    {
                        pawnInventory.createdPreviewCharacter.AddWeaponModel(weaponItem.modelPrefab, weaponItem.handlingType, false);
                    }
                    else
                    {
                        pawnInventory.createdPreviewCharacter.AddWeaponModel(weaponItem.modelPrefab, weaponItem.handlingType, true);
                    }
                    break;
                case WeaponHandlingType.TwoHanded:
                    pawnInventory.createdPreviewCharacter.AddWeaponModel(weaponItem.modelPrefab, weaponItem.handlingType, true);
                    break;
            }
        }

        public override void OnItemRemovedFromSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            if (slotNumberInList == -1)//Left Hand
            {
                pawnInventory.createdPreviewCharacter.DestroyWeaponModel( false);
            }
            else
            {
                pawnInventory.createdPreviewCharacter.DestroyWeaponModel(true);
            }
        }
    }
}
