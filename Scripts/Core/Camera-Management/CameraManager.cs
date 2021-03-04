using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core.Cameras
{
    public class CameraManager : IND_Mono
    {
        public Camera activeCamera;

        public override void Init()
        {

        }

        public override void Tick()
        {

        }


        public static CameraManager singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}