using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core {
    [CreateAssetMenu(fileName = "Scriptable1to100Float", menuName = "IND/Variables/Scriptable1to100Float")]
    public class Scriptable1to100Float : ScriptableObject {
        [Range(0, 100)]
        public float value;
		
	}
}