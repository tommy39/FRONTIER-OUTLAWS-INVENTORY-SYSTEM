using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "String", menuName = "IND/Variables/String")]
    public class ScriptableString : ScriptableObject {
        [MultiLineProperty]        public string value;
	}
}