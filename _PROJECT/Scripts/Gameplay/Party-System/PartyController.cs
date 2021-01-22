using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Inventory;

namespace IND.Gameplay.Party
{
    public class PartyController : IND_Mono
    {
        public PartyCampInventory campInventory;
        public List<PartyCharacter> partyCharacters = new List<PartyCharacter>();

        public override void Init()
        {
            //Automatically Setup Camp Inventory Index
            for (int i = 0; i < campInventory.partyInventoryItems.Count; i++)
            {
                campInventory.partyInventoryItems[i].inventorySlotIndex = i;
            }
        }

        public override void Tick()
        {

        }
    }
}