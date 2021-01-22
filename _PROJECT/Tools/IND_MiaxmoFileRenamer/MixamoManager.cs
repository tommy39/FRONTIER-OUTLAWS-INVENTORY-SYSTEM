
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace IND.DevTools.MixamoRenamer
{
    public class MixamoManager : OdinEditorWindow
    {
        private static MixamoManager editor;
        private static int width = 350;
        private static int height = 300;
        private static int x = 0;
        private static int y = 0;
        private static List<string> allFiles = new List<string>();

        public List<Object> animationsToUpdate = new List<Object>();

   [HideInInspector]   public Object singleTest;

        [MenuItem("IND Tools/Animation/Miaxamo Animation Renamer", false, 50)]
        static void ShowEditor()
        {
            editor = EditorWindow.GetWindow<MixamoManager>();
            CenterWindow();
        }


        [Button]
        void ClearList()
        {
            animationsToUpdate.Clear();
        }
        [Button]
        public void RenameAssignedAnimations()
        {

            for (int i = 0; i < animationsToUpdate.Count; i++)
            {
                string originalFile = Path.GetFileName(animationsToUpdate[i].ToString());

                if (originalFile.Contains("(UnityEngine.GameObject)"))
                {
                    string removeElement = " (UnityEngine.GameObject)";
                    originalFile = originalFile.Substring(0, originalFile.Length - removeElement.Length);
                }


                string modelPath = AssetDatabase.GetAssetPath(animationsToUpdate[i]);
                ModelImporter modelImporter = (ModelImporter)AssetImporter.GetAtPath(modelPath);

                RenameAndImport(modelImporter, originalFile);

            }
        }


        void RenameSingleAnimationTest()
        {

            string originalFile = Path.GetFileName(singleTest.ToString());

            if (originalFile.Contains("(UnityEngine.GameObject)"))
            {
                string removeElement = " (UnityEngine.GameObject)";
                originalFile = originalFile.Substring(0, originalFile.Length - removeElement.Length);
            }


            string modelPath = AssetDatabase.GetAssetPath(singleTest);
            ModelImporter modelImporter = (ModelImporter)AssetImporter.GetAtPath(modelPath);

            RenameAndImport(modelImporter, originalFile);
        }

        public void Rename()
        {
            DirSearch();

            if (allFiles.Count > 0)
            {
                for (int i = 0; i < allFiles.Count; i++)
                {
                    int idx = allFiles[i].IndexOf("Assets");
                    string asset = allFiles[i].Substring(idx);
                    string filename = Path.GetFileName(allFiles[i]);
                    AnimationClip orgClip = (AnimationClip)AssetDatabase.LoadAssetAtPath(
                        asset, typeof(AnimationClip));

                    var fileName = Path.GetFileNameWithoutExtension(allFiles[i]);
                    var importer = (ModelImporter)AssetImporter.GetAtPath(asset);

                    RenameAndImport(importer, fileName);
                }
            }
        }

        private void RenameAndImport(ModelImporter asset, string name)
        {
            Debug.Log(name);
            Debug.Log(asset);

            ModelImporter modelImporter = asset as ModelImporter;
            ModelImporterClipAnimation[] clipAnimations = modelImporter.defaultClipAnimations;

            for (int i = 0; i < clipAnimations.Length; i++)
            {
                clipAnimations[i].name = name;
            }

            modelImporter.clipAnimations = clipAnimations;
            modelImporter.SaveAndReimport();

            AssetDatabase.Refresh();
        }

        private static void CenterWindow()
        {
            editor = EditorWindow.GetWindow<MixamoManager>();
            x = (Screen.currentResolution.width - width) / 2;
            y = (Screen.currentResolution.height - height) / 2;
            editor.position = new Rect(x, y, width, height);
            editor.maxSize = new Vector2(width, height);
            editor.minSize = editor.maxSize;
        }

        static void DirSearch()
        {
            string info = Application.dataPath + "/_ProjectDirectory/Animations/";
            string[] fileInfo = Directory.GetFiles(info +"/_ProjectDirectory/Animations/", "*.fbx", SearchOption.AllDirectories);
            foreach (string file in fileInfo)
            {
                if (file.EndsWith(".fbx"))
                    allFiles.Add(file);
            }
        }
    }
}