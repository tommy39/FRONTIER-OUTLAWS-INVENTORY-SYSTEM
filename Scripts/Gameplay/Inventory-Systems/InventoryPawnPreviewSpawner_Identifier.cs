using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Inventory
{
    /// <summary>Identifier class for parent transform to use for spawning the inventory render character</summary>
    public class InventoryPawnPreviewSpawner_Identifier : IND_Mono
    {
        public static InventoryPawnPreviewSpawner_Identifier singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}