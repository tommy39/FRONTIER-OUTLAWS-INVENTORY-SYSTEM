using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Inventory.UI
{
    [CreateAssetMenu(fileName = "Inventory Manager Data - UI", menuName = "IND/Gameplay/Inventory/Inventory Manager Data - UI")]
    public class InventoryManagerData_UI : ScriptableObject
    {
        public Sprite bgBackpackIcon;
        public Sprite bgWeaponIcon;
        public Sprite bgHeadIcon;
        public Sprite bgBodyIcon;

        public Color emptySlotIconColor;
    }
}