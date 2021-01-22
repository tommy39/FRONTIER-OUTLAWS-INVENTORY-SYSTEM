using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IND.Core.Tooltips
{
    public class TooltipTriggerController : IND_Mono, IPointerEnterHandler, IPointerExitHandler
    {
        public static LTDescr delay;
        public string header;

        [Multiline()]
        public string content;

        public void OnPointerEnter(PointerEventData eventData)
        {
            delay = LeanTween.delayedCall(0.5f, () =>
            {
                TooltipManager.Show(content, header);
            });
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.cancel(delay.uniqueId);
            TooltipManager.Hide();
        }
    }
}