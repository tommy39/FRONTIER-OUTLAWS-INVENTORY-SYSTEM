using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Core.CharacterClothing
{
    [CreateAssetMenu(fileName = "Character-Model-Data", menuName = "IND/Core/Character-Model-Data")]
    public class CharacterModelData : ScriptableObject
    {
        public GameObject characterBasePrefab;
    }
}