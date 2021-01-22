using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu (fileName = "LayerMask", menuName = "IND/Variables/LayerMask")]
public class ScriptableLayerMask : ScriptableObject {

        public LayerMask value;	
		
	}
}