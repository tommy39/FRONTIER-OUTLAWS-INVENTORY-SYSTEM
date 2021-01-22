using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

namespace IND.Core
{
    [CreateAssetMenu(fileName = "Animation", menuName = "IND/Variables/Animation")]
    public class ScriptableAnimation : ScriptableObject
    {
        public string animName;
        public int animHash;

#if UNITY_EDITOR
        [Button]
#endif
        void CreateHash()
        {
            animHash = Animator.StringToHash(animName);
        }
    }
}