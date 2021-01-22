using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "Bool", menuName = "IND/Variables/Bool")]
    public class ScriptableBool : ScriptableObject {
        [ShowInInspector]
        public bool value;
		
	}
}