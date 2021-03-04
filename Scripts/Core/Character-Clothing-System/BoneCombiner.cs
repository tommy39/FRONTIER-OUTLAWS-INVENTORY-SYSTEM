using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Core.CharacterClothing
{
    public class BoneCombiner
    {
        public readonly Dictionary<int, Transform> _rootBoneDictionary = new Dictionary<int, Transform>();
        private readonly Transform[] _boneTransforms = new Transform[67];
        private GameObject originalGameObj;
        public GameObject createdGameObject;
        private readonly Transform _transform;

        public BoneCombiner(GameObject rootObj)
        {
            _transform = rootObj.transform;
            TraverseHierachy(_transform);
        }

        public Transform AddLimb(GameObject bonedObj)
        {
            originalGameObj = bonedObj;
            Transform limb = ProcessBonedObject(renderer: bonedObj.GetComponentInChildren<SkinnedMeshRenderer>());
            limb.SetParent(_transform);
            return limb;
        }

        private Transform ProcessBonedObject(SkinnedMeshRenderer renderer)
        {
            Transform bonedObject = new GameObject().transform;
            bonedObject.gameObject.name = originalGameObj.name;
            SkinnedMeshRenderer meshRender = bonedObject.gameObject.AddComponent<SkinnedMeshRenderer>();

            Transform[] bones = renderer.bones;
            for (int i = 0; i < bones.Length; i++)
            {
                _boneTransforms[i] = _rootBoneDictionary[bones[i].name.GetHashCode()];
            }

            meshRender.bones = _boneTransforms;
            meshRender.sharedMesh = renderer.sharedMesh;
            meshRender.materials = renderer.sharedMaterials;

            createdGameObject = bonedObject.gameObject;

            return bonedObject;
        }

        private void TraverseHierachy(Transform trans)
        {
            foreach (Transform child in trans)
            {
                _rootBoneDictionary.Add(child.name.GetHashCode(), child);
                TraverseHierachy(child);
            }
        }
    }
}