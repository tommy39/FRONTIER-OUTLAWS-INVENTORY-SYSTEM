using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Inventory.UI
{
    [System.Serializable]
    /// <summary>Defines What Type Of Slot it is for extra functionality e.g. backpack or weapon slot</summary>
    public enum InventorySlotType_UI
    {
        backpack, head, body, weapon
    }
}