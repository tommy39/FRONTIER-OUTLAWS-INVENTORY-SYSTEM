using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace IND.Core.Tooltips
{
    [ExecuteInEditMode()]
    public class TooltipController_UI : IND_Mono
    {
        public TextMeshProUGUI headerField;
        public TextMeshProUGUI contentField;
        public LayoutElement layoutElement;
        [OnValueChanged("UpdateTextBoxSize")]
        public int characterWrapLimit;
        [HideInInspector] public bool isActive = false;
        [SerializeField] protected float tooltipXOffset = 1f;
        public RectTransform rectTransform;

        public void SetText(string content, string header = "")
        {
            if (string.IsNullOrEmpty(header))
            {
                headerField.gameObject.SetActive(false);
            }
            else
            {
                headerField.gameObject.SetActive(true);
                headerField.text = header;
            }
            contentField.text = content;

            UpdateTextBoxSize();

            LateUpdate();
        }



        private void UpdateTextBoxSize()
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;
            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        private void LateUpdate()
        {
            if (isActive == true)
            {
                Vector2 position = Input.mousePosition;

                float pivotX = (position.x / Screen.width) - tooltipXOffset;
                float pivotY = position.y / Screen.height;

                rectTransform.pivot = new Vector2(pivotX, pivotY);
                transform.position = position;
            }
        }
    }
}