using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace IND.DevTools
{
    public class IND_ObjectReplacer : EditorWindow
    {

        private static IND_ObjectReplacer Window;
        #region Public Data
        private GameObject objectTypeToReplace;
        private GameObject replaceWithThis;

        private ReplacementMethod replacementMethod = ReplacementMethod.StringBased;
        #endregion


        #region Private Data
        private List<GameObject> geoObjectsToReplace = new List<GameObject>();
        SerializedProperty m_IntProp;


        #endregion
        private void OnEnable()
        {


            //     Init();
        }
        [MenuItem("IND Tools/Level Design/Object Replacer")]
        private static void ShowWindow()
        {
            Window = (IND_ObjectReplacer)GetWindow(typeof(IND_ObjectReplacer), false, "Object Replacer");
            Vector2 windowMinSize = Window.minSize;
            windowMinSize.x = 100;
            windowMinSize.y = 125;
            Window.minSize = windowMinSize;

        }

        void OnGUI()
        {
            Rect lastRect;
            GUILayout.BeginVertical();
            {
                GUILayout.Label("Object Replacer Settings", EditorStyles.boldLabel);

                replacementMethod = (ReplacementMethod)EditorGUILayout.EnumPopup("Method of Replacement", replacementMethod);

                objectTypeToReplace = (GameObject)EditorGUILayout.ObjectField("Object Type To Replace", objectTypeToReplace, typeof(GameObject), true);
                replaceWithThis = (GameObject)EditorGUILayout.ObjectField("Replace With This Prefab", replaceWithThis, typeof(GameObject), true);

                if (GUILayout.Button("Replace Objects!"))
                {
                    if (objectTypeToReplace == null || replaceWithThis == null)
                    {
                        ShowNotification(new GUIContent("No object selected for searching"));
                        //   return;
                    }
                    else
                    {
                        ReplaceObjects();
                    }

                    lastRect = GUILayoutUtility.GetLastRect();
                }
            }
            GUILayout.EndVertical();
            lastRect = GUILayoutUtility.GetLastRect();    //button rect    


            // GUILayout.BeginArea(new Rect(10, 10, 300, 500));
            //      replaceWithThis = (GameObject)EditorGUI.ObjectField(new Rect(3, 60, position.width - 6, 20), "Replace With This", replaceWithThis, typeof(GameObject));




            //       GUILayout.EndArea();
            // ApplyModifiedProperties();
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }

        void ReplaceObjects()
        {
            geoObjectsToReplace.Clear();
            FindAllInstances();

            for (int i = 0; i < geoObjectsToReplace.Count; i++)
            {
                Transform originalParent = geoObjectsToReplace[i].transform.parent;


                GameObject newObject = Instantiate(replaceWithThis, originalParent);
                newObject.transform.localPosition = geoObjectsToReplace[i].transform.localPosition;
                newObject.transform.localRotation = geoObjectsToReplace[i].transform.localRotation;
                newObject.transform.localScale = geoObjectsToReplace[i].transform.localScale;
                DestroyImmediate(geoObjectsToReplace[i]);
                Debug.Log("Replaced Object");
            }
            Debug.Log("Replace Objects");
        }

        void FindAllInstances()
        {
            List<GameObject> result = new List<GameObject>();
            GameObject[] allObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
            foreach (GameObject GO in allObjects)
            {
                Debug.Log(GO.name);
                string objectName = objectTypeToReplace.name;
                if (GO.name.Contains(objectName))
                {
                    Debug.Log(GO.name + " 2.0");
                    geoObjectsToReplace.Add(GO);
                }
            }
        }


        enum ReplacementMethod { StringBased }

    }
}
