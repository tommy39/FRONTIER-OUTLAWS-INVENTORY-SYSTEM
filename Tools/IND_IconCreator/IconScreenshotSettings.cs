using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Tools.IconCreator
{
    [CreateAssetMenu(fileName = "Icon-Screenshot-Settings", menuName = "IND/Tools/Icon Creator/Settings")]
    public class IconScreenshotSettings : ScriptableObject
    {
        public int imageWidth = 1024;
        public int imageHeight = 1024;
        public string folderDirectory = "Screenshots";
        public string filenamePrefix = "Icon";

        public bool savedImageAsItemIcon = true;
    }
}