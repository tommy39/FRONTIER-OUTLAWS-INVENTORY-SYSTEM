using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

/// <summary>
/// Used to reset Inputs at the end of all scripts execution
/// </summary>
namespace IND.Core.Inputs
{
    public class InputManagerResetter : IND_Mono
    {
        private InputManager inputManager;

        public override void Init()
        {
            inputManager = GetComponent<InputManager>();
        }
        public override void Tick()
        {
            inputManager.ResetRegularInput();
        }
        public override void FixedTick()
        {
            inputManager.ResetFixedInput();
        }

       
    }


}