using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "Event", menuName = "IND/Variables/ScriptableEvent")]
    public class ScriptableEvent : ScriptableObject {

	public virtual void Execute(Transform trans = null)
        {

        }
	}
}