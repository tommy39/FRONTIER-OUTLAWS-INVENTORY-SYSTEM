using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using System.IO;
using UnityEditor;

namespace IND.Tools.IconCreator
{
    [ExecuteInEditMode()]
    public class IconCreatorManager : MonoBehaviour
    {
        [ValueDropdown("availableItems"), OnValueChanged("OnSelectedItemChanged")]
        public string selectedItemName;
        [InlineEditor] public IconScreenshotSettings settings;
        [HideInInspector] public List<string> availableItems = new List<string>();

        [HideInInspector] public IconCreatorItem selectedItemClass;

        [InlineEditor] public IconCreatorData data;

        public GameObject createdItemGameobject;
        private bool takeScreenshotOnNextFrame = false;

        [ExecuteInEditMode()]
        private void Update()
        {
            for (int i = 0; i < data.iconItems.Count; i++)
            {
                if (data.iconItems[i].item != null)
                {
                    string itemName = data.iconItems[i].item.itemName;
                    if (!selectedItemName.Contains(itemName))
                    {
                        availableItems.Add(itemName);
                    }
                }
            }

            for (int i = 0; i < availableItems.Count; i++)
            {
                bool nameFound = false;
                for (int g = 0; g < data.iconItems.Count; g++)
                {
                    if (data.iconItems[g].item.itemName == availableItems[i])
                    {
                        nameFound = true;
                        break;
                    }
                }

                if (nameFound == false)
                {
                    availableItems.Remove(availableItems[i]);
                }
            }

            if (createdItemGameobject != null)
            {
                UpdateCurrentItem();
            }
        }

        private void UpdateCurrentItem()
        {
            selectedItemClass.localPos = createdItemGameobject.transform.localPosition;
            selectedItemClass.localRotation = createdItemGameobject.transform.localRotation;
            selectedItemClass.localScale = createdItemGameobject.transform.localScale;
        }

        private void OnSelectedItemChanged()
        {
            RemoveItem();
            for (int i = 0; i < data.iconItems.Count; i++)
            {
                if (data.iconItems[i].item.itemName == selectedItemName)
                {
                    selectedItemClass = data.iconItems[i];
                    SpawnItem();
                    break;
                }
            }
        }

        private IEnumerable GetListOfItems()
        {
            for (int i = 0; i < data.iconItems.Count; i++)
            {
                yield return data.iconItems[i];
            }
        }

        private void SpawnItem()
        {
            if (selectedItemClass.item.modelPrefab != null)
            {
                createdItemGameobject = Instantiate(selectedItemClass.item.modelPrefab, transform);
                if (selectedItemClass.localScale != Vector3.zero)
                {
                    createdItemGameobject.transform.localPosition = selectedItemClass.localPos;
                    createdItemGameobject.transform.localRotation = selectedItemClass.localRotation;
                    createdItemGameobject.transform.localScale = selectedItemClass.localScale;
                }
                else
                {
                    createdItemGameobject.transform.localPosition = Vector3.zero;
                }
            }
        }

        private void RemoveItem()
        {
            if (selectedItemClass.item != null)
            {
                DestroyImmediate(createdItemGameobject);
            }
        }

        private bool IsEditorPlaying()
        {
            if (Application.isPlaying)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [ShowIf("IsEditorPlaying")]
        [Button(100)]
        private void CaptureImage()
        {
            Camera cam = FindObjectOfType<Camera>();

            int width = settings.imageWidth;
            int height = settings.imageHeight;
            string folder = settings.folderDirectory;
            string filenamePrefix = settings.filenamePrefix;
            bool ensureTransparentBackground = true;

            folder = GetSafePath(folder.Trim('/'));
            filenamePrefix = GetSafeFilename(filenamePrefix);

            string dir = Application.dataPath + "/" + folder + "/";
            string filename = filenamePrefix + "_" + selectedItemName + ".png";
            string path = dir + filename;

            // Create Render Texture with width and height.
            RenderTexture rt = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);

            // Assign Render Texture to camera.
            cam.targetTexture = rt;

            // save current background settings of the camera
            CameraClearFlags clearFlags = cam.clearFlags;
            Color backgroundColor = cam.backgroundColor;

            // make the background transparent when enabled
            if (ensureTransparentBackground)
            {
                cam.clearFlags = CameraClearFlags.SolidColor;
                cam.backgroundColor = new Color(); // alpha is zero
            }

            // Render the camera's view to the Target Texture.
            cam.Render();

            // restore the camera's background settings if they were changed before rendering
            if (ensureTransparentBackground)
            {
                cam.clearFlags = clearFlags;
                cam.backgroundColor = backgroundColor;
            }

            // Save the currently active Render Texture so we can override it.
            RenderTexture currentRT = RenderTexture.active;

            // ReadPixels reads from the active Render Texture.
            RenderTexture.active = cam.targetTexture;

            // Make a new texture and read the active Render Texture into it.
            Texture2D screenshot = new Texture2D(width, height, TextureFormat.ARGB32, false);
            screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);

            // PNGs should be sRGB so convert to sRGB color space when rendering in linear.
            if (QualitySettings.activeColorSpace == ColorSpace.Linear)
            {
                Color[] pixels = screenshot.GetPixels();
                for (int p = 0; p < pixels.Length; p++)
                {
                    pixels[p] = pixels[p].gamma;
                }
                screenshot.SetPixels(pixels);
            }

            // Apply the changes to the screenshot texture.
            screenshot.Apply(false);

            // Save the screnshot.
            Directory.CreateDirectory(dir);
            byte[] png = screenshot.EncodeToPNG();
            File.WriteAllBytes(path, png);

            // Remove the reference to the Target Texture so our Render Texture is garbage collected.
            cam.targetTexture = null;

            // Replace the original active Render Texture.
            RenderTexture.active = currentRT;

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            string spritePath = SetImageAsSprite();
            UpdateScriptableObjectData(spritePath);
            
        }


        private string SetImageAsSprite()
        {
            string path = "Assets/" + settings.folderDirectory + "/" + settings.filenamePrefix + "_" + selectedItemName + ".png";
            var importer = AssetImporter.GetAtPath(path) as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return path;
        }

        private void UpdateScriptableObjectData(string path)
        {
            if (settings.savedImageAsItemIcon == false)
                return;

            Sprite text = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
            selectedItemClass.item.inventoryIcon = text;
            EditorUtility.SetDirty(selectedItemClass.item);
        }

        public string GetSafePath(string path)
        {
            return string.Join("_", path.Split(Path.GetInvalidPathChars()));
        }

        public string GetSafeFilename(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

    }
}