using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

namespace IND.DevTools.AnimationSampler
{
    public class AnimationSampler : OdinEditorWindow
    {
  [OnValueChanged("SampleAnimation")]      public AnimationClip animationToSample;
        public float animationLength;

        [MenuItem("IND Tools/Animation/Animation Sampler", false, 55)]
        private static void OpenAnimatioNSamplerInterface()
        {

            var window = GetWindow<AnimationSampler>();
       

            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 200);


        }

        public void SampleAnimation()
        {
            animationLength= animationToSample.length;
        }
    }
}