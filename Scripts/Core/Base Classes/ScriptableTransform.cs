using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "Transform", menuName = "IND/Variables/Transform")]
    public class ScriptableTransform : ScriptableObject {

        public Transform value;
		
	}
}