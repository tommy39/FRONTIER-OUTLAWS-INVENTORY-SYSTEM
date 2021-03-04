using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Inventory.UI
{
    public class InventorySlot_Head_UI : InventorySlot_UI
    {
        public override void OnItemAddedToSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            GameObject createdGeo = Instantiate(assignedItem.itemData.modelPrefab, pawnInventory.previewPawnSpawner.transform);
            pawnInventory.createdPreviewCharacter.AddLimbModel(createdGeo, slotType);
            Destroy(createdGeo);
        }

        public override void OnItemRemovedFromSlot()
        {
            InventoryPawn_UI pawnInventory = GetComponentInParent<InventoryPawn_UI>();
            pawnInventory.createdPreviewCharacter.RemoveLimbModel(slotType);
        }
    }
}