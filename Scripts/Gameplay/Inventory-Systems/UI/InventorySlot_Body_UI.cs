using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IND.Gameplay.Items;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Inventory.UI
{
    public class InventorySlot_Body_UI : InventorySlot_UI
    {
        public override void OnItemAddedToSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            BodyClothingItemData clothItem = assignedItem.itemData as BodyClothingItemData;
            for (int i = 0; i < clothItem.meshesToCreate.Count; i++)
            {
                GameObject createdGeo = Instantiate(clothItem.meshesToCreate[i], pawnInventory.previewPawnSpawner.transform);
                pawnInventory.createdPreviewCharacter.AddLimbModel(createdGeo, slotType);
                Destroy(createdGeo);
            }
        }

        public override void OnItemRemovedFromSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            pawnInventory.createdPreviewCharacter.RemoveLimbModel(slotType);
        }
    }
}