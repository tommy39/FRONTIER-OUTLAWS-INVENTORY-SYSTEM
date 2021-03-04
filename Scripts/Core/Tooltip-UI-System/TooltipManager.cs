using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IND.Core.Tooltips
{
    public class TooltipManager : IND_Mono
    {
        public TooltipController_UI tooltipController;
        public static LTDescr delay;

        public static void Show(string content, string header = "")
        {
            if (string.IsNullOrEmpty(content) && string.IsNullOrEmpty(header))
                return;

            singleton.tooltipController.gameObject.SetActive(true);
            singleton.tooltipController.SetText(content, header);
            singleton.tooltipController.isActive = true;
        }

        public static void Hide()
        {
            singleton.tooltipController.gameObject.SetActive(false);
            singleton.tooltipController.isActive = false;
        }

        public static TooltipManager singleton;
        private void Awake()
        {
            singleton = this;
            tooltipController.gameObject.SetActive(false);
        }
    }
}