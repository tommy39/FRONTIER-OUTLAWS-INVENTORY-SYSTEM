using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core.DevTools{
public class IND_DrawPhysicsOverlapSphere : MonoBehaviour
{
        public float drawRadius = 1f;
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, drawRadius);
        }
    }
}