using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "GameObject", menuName = "IND/Variables/Game Object")]
    public class ScriptableGameObject : ScriptableObject {
        public GameObject value;
	}
}