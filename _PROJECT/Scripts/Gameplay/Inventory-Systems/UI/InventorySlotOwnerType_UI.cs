using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Gameplay.Inventory.UI
{
    [System.Serializable]
    /// <summary>Defines What Type Of Inventory It Is e.g. Pawn Inventory or Party Inventory</summary>
    public enum InventorySlotOwnerType_UI
    {
        Character, Party
    }
}