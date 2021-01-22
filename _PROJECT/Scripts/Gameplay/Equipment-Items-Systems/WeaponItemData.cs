using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Items
{
    [CreateAssetMenu(fileName = "Item_Weapon Base Class", menuName = "IND/Gameplay/Items/Weapon Base Class")]
    public class WeaponItemData : ItemData
    {
        public WeaponHandlingType handlingType;
        public string inventoryRenderPreviewAnimName = "idle";


        public Vector3 rightHandLocalPos;
        public Quaternion rightHandLocalRot;

        [ShowIf("handlingType", WeaponHandlingType.OneHanded)]
        public Vector3 leftHandLocalPos;
        [ShowIf("handlingType", WeaponHandlingType.OneHanded)]
        public Quaternion leftHandLocalRot;
    }
}