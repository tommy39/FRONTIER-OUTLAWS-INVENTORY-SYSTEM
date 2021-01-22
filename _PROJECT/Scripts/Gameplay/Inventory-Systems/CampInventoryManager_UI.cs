using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Party;

namespace IND.Gameplay.Inventory.UI
{
    /// <summary>Is an Inventory Controller for the players party camp</summary>
    public class CampInventoryManager_UI : IND_Mono
    {
        [HideInInspector] public List<InventorySlot_UI> slots = new List<InventorySlot_UI>();
        [SerializeField] protected Transform slotsGrid;

        public PartyController partyController;
        [HideInInspector] public PartyCampInventory partyCampInventory;

        public override void Init()
        {
            InventorySlot_UI[] slotsInGrid = GetComponentsInChildren<InventorySlot_UI>();
            foreach (InventorySlot_UI item in slotsInGrid)
            {
                slots.Add(item);
            }

            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].slotNumberInList = i;
                slots[i].slotOwnerType = InventorySlotOwnerType_UI.Party;
                slots[i].Init();
            }



            partyCampInventory = partyController.campInventory;

            //Setup Inventory
            for (int i = 0; i < partyCampInventory.partyInventoryItems.Count; i++)
            {
                Inventory_UI_Static.AssignItemToEmptySlot(slots[i], partyCampInventory.partyInventoryItems[i], InventorySlotOwnerType_UI.Party, i, null, partyCampInventory);
            }
        }

        public static CampInventoryManager_UI singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}