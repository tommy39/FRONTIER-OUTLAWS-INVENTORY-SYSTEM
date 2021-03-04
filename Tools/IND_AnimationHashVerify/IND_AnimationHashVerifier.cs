using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [System.Serializable]
    public class IND_AnimationHashVerifier
    {
        [MenuItem("IND Tools/Animation/CreateAnimationHashes", false, 66)]
        public static void SetHashesForAllAnims()
        {

            List<ScriptableAnimation> allGameAnimations = new List<ScriptableAnimation>();

            object[] anims = Resources.LoadAll("Animations", typeof(ScriptableAnimation));

            foreach (object item in anims)
            {
                allGameAnimations.Add(item as ScriptableAnimation);
            }

            for (int i = 0; i < allGameAnimations.Count; i++)
            {
                allGameAnimations[i].animHash = Animator.StringToHash(allGameAnimations[i].animName);
            }
        }

    }
}
