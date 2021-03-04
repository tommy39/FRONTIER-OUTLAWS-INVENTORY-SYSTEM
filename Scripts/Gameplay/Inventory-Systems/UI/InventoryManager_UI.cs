using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using UnityEngine.UI;

namespace IND.Gameplay.Inventory.UI
{
    /// <summary>Responsbile for storing all core inventory data for all inventory types</summary>
    public class InventoryManager_UI : IND_Mono
    {
        [InlineEditor] public InventoryManagerData_UI data;

        public static Canvas canvas;
        public static InventoryDraggableItem_UI draggableItem;

        public override void Init()
        {
            draggableItem = GetComponentInChildren<InventoryDraggableItem_UI>();
            draggableItem.gameObject.SetActive(false);
            canvas = GetComponentInParent<Canvas>();

            AssignIconsToStatic();
            Inventory_UI_Static.emptyIconColor = data.emptySlotIconColor;
        }

        /// <summary>Updates The Static Icon References</summary>
        private void AssignIconsToStatic()
        {
            Inventory_UI_Static.bgBodyIcon = data.bgBodyIcon;
            Inventory_UI_Static.bgHeadIcon = data.bgHeadIcon;
            Inventory_UI_Static.bgBackpackIcon = data.bgBackpackIcon;
            Inventory_UI_Static.bgWeaponIcon = data.bgWeaponIcon;
        }
    }
}