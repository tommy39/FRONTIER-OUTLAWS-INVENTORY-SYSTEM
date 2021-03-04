using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core.DevTools.OnScreenDebug
{
    public class IND_OnScreenDebug : MonoBehaviour
    {
        public GameObject textPrefabObject;
        public void CreateDebug(Vector3 worldSpacePosition, string text)
        {
            GameObject geo = Instantiate(textPrefabObject, transform);
            geo.transform.position = new Vector3(worldSpacePosition.x, worldSpacePosition.y += 2f, worldSpacePosition.z); 
            IND_OnScreenDebugText textDebugger = geo.GetComponent<IND_OnScreenDebugText>();
            textDebugger.SetupText(text);
        }

        public static IND_OnScreenDebug singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}