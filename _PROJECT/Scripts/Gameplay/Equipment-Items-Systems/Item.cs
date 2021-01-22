using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Items
{
    [System.Serializable]
    public class Item
    {
        [InlineEditor] public ItemData itemData;
        [ShowIf("itemController")] [InlineEditor] public ItemController itemController;
        public int inventorySlotIndex;
        public int currentStackAmount = 1;

    }
}