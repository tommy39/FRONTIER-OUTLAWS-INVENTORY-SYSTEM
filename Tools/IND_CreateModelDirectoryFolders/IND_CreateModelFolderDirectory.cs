using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using System.IO;

namespace IND.DevTools.CreateModelFolderDirectory
{
    public static class IND_CreateModelFolderDirectory
    {
        [MenuItem("Assets/Create/Create 3D Model Directory", false, 100)]
        public static void CreateDirectory()
        {
            string folderPath = "";
            var obj = Selection.activeObject;

            if (obj == null)
            {
                Debug.LogError("No Folder Found");
                return;
            }
            else
            {
                folderPath = AssetDatabase.GetAssetPath(obj.GetInstanceID());
            }

            var geoFolder = Directory.CreateDirectory(folderPath + "/Geometry");
            var materialsFolder = Directory.CreateDirectory(folderPath + "/Materials");
            var texturesFolder = Directory.CreateDirectory(folderPath + "/Textures");

            AssetDatabase.Refresh();
        }
    }
}