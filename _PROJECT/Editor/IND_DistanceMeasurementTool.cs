using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

namespace IND.Core.DevTools.Measurement
{
    public class IND_DistanceMeasurementTool : MonoBehaviour
    {
        [Header("Straight Line Measurement")]
        public float distanceToCastRay = 10f;

        [Header("Measure Between Transform to another Object")]
        public Transform objectToMeasureToo;
        public float distanceBetweenTarget;

#if UNITY_EDITOR	
        private void OnDrawGizmos()
        {
            Handles.color = Color.red;

            Handles.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceToCastRay));

            if (objectToMeasureToo != null)
            {
                Handles.DrawLine(transform.position, objectToMeasureToo.position);
                distanceBetweenTarget = Vector3.Distance(transform.position, objectToMeasureToo.position);
            }
        }
#endif
    }
}