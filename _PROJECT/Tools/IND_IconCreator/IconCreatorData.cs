using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Tools.IconCreator
{
    [CreateAssetMenu(fileName = "Icon-Creator-Data", menuName = "IND/Tools/Icon Creator/Data")]
    public class IconCreatorData : ScriptableObject
    {
        public List<IconCreatorItem> iconItems = new List<IconCreatorItem>();
    }
}