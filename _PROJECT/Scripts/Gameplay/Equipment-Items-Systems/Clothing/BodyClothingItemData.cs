using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Items
{
    [CreateAssetMenu(fileName = "BodyClothingItemData", menuName = "IND/Gameplay/Items/Body Clothing Item")]
    public class BodyClothingItemData : ClothingItemData
    {
        public List<GameObject> meshesToCreate = new List<GameObject>();
    }
}