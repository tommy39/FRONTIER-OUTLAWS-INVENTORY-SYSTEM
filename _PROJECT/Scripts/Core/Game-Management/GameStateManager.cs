using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IND.Core.Managers
{
    public class GameStateManager : IND_Mono
    {
        public ScriptableBool pauseGameInput;
        [InlineEditor] public ScriptableBool isGamePaused;

        public override void Init()
        {
            isGamePaused.value = false;
        }

        public override void Tick()
        {
#if UNITY_EDITOR
            CheckForInput();
#endif
        }

#if UNITY_EDITOR
        private void CheckForInput()
        {
            if (pauseGameInput.value == true)
            {
                if (isGamePaused.value == true)
                {
                    UnPauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        private void PauseGame()
        {
            isGamePaused.value = true;
            Time.timeScale = 0;
        }

        private void UnPauseGame()
        {
            isGamePaused.value = false;
            Time.timeScale = 1;
        }
#endif
    }
}