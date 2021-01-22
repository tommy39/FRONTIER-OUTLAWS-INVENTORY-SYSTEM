using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

namespace IND.Core.DevTools.OnScreenDebug{
    [DefaultExecutionOrder(1000)]
    public class IND_OnScreenDebugText : MonoBehaviour
{
        private TextMeshPro textMesh;
        private float moveYSpeed = 1f;

        private float disappearTimer = 1f;
        public void Start()
        {
            textMesh = GetComponent<TextMeshPro>();
        }

        public void SetupText(string text)
        {
            textMesh.text = text;
        }

        private void Update()
        {
            transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
            disappearTimer -= Time.deltaTime;
            if(disappearTimer < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}