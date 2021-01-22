using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Items;
using IND.Gameplay.Inventory;

namespace IND.Gameplay.Inventory.UI
{
    /// <summary>A Modular Class for all pawns that is used to give an interface for their Inventories</summary>
    public class InventoryPawn_UI : IND_Mono
    {
        [FoldoutGroup("Slots")] public List<InventorySlot_UI> beltSlots = new List<InventorySlot_UI>();
        [FoldoutGroup("Slots")] [SerializeField] protected InventorySlot_UI headSlot;
        [FoldoutGroup("Slots")] [SerializeField] protected InventorySlot_UI bodySlot;
        [FoldoutGroup("Slots")] public InventorySlot_UI rightHandSlot;
        [FoldoutGroup("Slots")] public InventorySlot_UI leftHandSlot;

        public PartyCharacterInventory characterInventory;
        [HideInInspector] public InventoryPawnPreviewSpawner_Identifier previewPawnSpawner;
        public CharacterRenderInventoryController createdPreviewCharacter;

        public override void Init()
        {
            previewPawnSpawner = InventoryPawnPreviewSpawner_Identifier.singleton;

            //Setup Slot Belt Numbers
            for (int i = 0; i < beltSlots.Count; i++)
            {
                beltSlots[i].slotNumberInList = i;
                beltSlots[i].Init();
            }

            leftHandSlot.Init();
            rightHandSlot.Init();
            bodySlot.Init();
            headSlot.Init();

            leftHandSlot.slotNumberInList = -1;
            rightHandSlot.slotNumberInList = -2;
        }

        /// <summary>Called When the Inventory of a target character is opened</summary>
        public void SetupNewSelectionInventory(PartyCharacterInventory inventory)
        {
            characterInventory = inventory;
            SpawnRenderCharacter();

            if (inventory.headEquipmentItem.itemData != null)
            {
                Inventory_UI_Static.AssignItemToEmptySlot(headSlot, inventory.headEquipmentItem, InventorySlotOwnerType_UI.Character, 0);
            }
            else
            {
                Inventory_UI_Static.RemoveItemFromSlot(headSlot);
            }

            if (inventory.bodyEquipmentItem.itemData != null)
            {
                Inventory_UI_Static.AssignItemToEmptySlot(bodySlot, inventory.bodyEquipmentItem, InventorySlotOwnerType_UI.Character, 0);
            }
            else
            {
                Inventory_UI_Static.RemoveItemFromSlot(bodySlot);
            }

            if (inventory.rightHandWeaponItem.itemData != null)
            {
                Inventory_UI_Static.AssignItemToEmptySlot(rightHandSlot, inventory.rightHandWeaponItem, InventorySlotOwnerType_UI.Character, 0);
            }
            else
            {
                Inventory_UI_Static.RemoveItemFromSlot(rightHandSlot);
            }

            if (inventory.leftHandWeaponItem.itemData != null)
            {
                Inventory_UI_Static.AssignItemToEmptySlot(leftHandSlot, inventory.leftHandWeaponItem, InventorySlotOwnerType_UI.Character, 0);
            }
            else
            {
                Inventory_UI_Static.RemoveItemFromSlot(leftHandSlot);
            }

            for (int i = 0; i < beltSlots.Count; i++) //Clear Existing Belt
            {
                Inventory_UI_Static.ClearUISlot(beltSlots[i]);
            }

            if (inventory.beltItems.Count > 0)
            {

                for (int i = 0; i < inventory.beltItems.Count; i++)
                {
                    if (inventory.beltItems[i] != null)
                    {
                        Inventory_UI_Static.AssignItemToEmptySlot(beltSlots[i], inventory.beltItems[i], InventorySlotOwnerType_UI.Character, i);
                    }
                }
            }
        }

        /// <summary>Creates a 3d Character To be rendered by our camera to give a preview of the characters equipment in the inventory interface</summary>
        private void SpawnRenderCharacter()
        {
            if(createdPreviewCharacter != null)
            {
                Destroy(createdPreviewCharacter.gameObject);
            }

            GameObject geo = Instantiate(characterInventory.characterModelBasePrefab, previewPawnSpawner.transform);
            createdPreviewCharacter = geo.GetComponent<CharacterRenderInventoryController>();
            createdPreviewCharacter.OnSpawn(characterInventory);
        }
    }
}