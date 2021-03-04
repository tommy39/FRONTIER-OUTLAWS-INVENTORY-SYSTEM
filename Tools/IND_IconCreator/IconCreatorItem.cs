using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Items;

namespace IND.Tools.IconCreator
{
    [ExecuteInEditMode()]
    [System.Serializable]
    public class IconCreatorItem
    {
        [InlineEditor] public ItemData item;
        public Vector3 localPos;
        public Quaternion localRotation;
        public Vector3 localScale;
    }
}