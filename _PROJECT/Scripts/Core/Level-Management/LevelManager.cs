using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core.GameLevels;
using UnityEngine.SceneManagement;


namespace IND.Core.LevelManagement
{

    public class LevelManager : IND_Mono
    {
        public List<GameLevel> activeGameLevels = new List<GameLevel>();
        public List<LevelComponentController> activeGameLevelComponentsControllers = new List<LevelComponentController>();

        [SerializeField] protected bool useEditorQuickStart = true;

        public override void Init()
        {
            if(useEditorQuickStart == true)
            {
                LevelComponentController[] components = FindObjectsOfType<LevelComponentController>();
                foreach (LevelComponentController item in components)
                {
                    activeGameLevelComponentsControllers.Add(item);
                    if(!activeGameLevels.Contains(item.gameLevel))
                    {
                        activeGameLevels.Add(item.gameLevel);
                    }
                }
            }

            for (int i = 0; i < activeGameLevelComponentsControllers.Count; i++)
            {
                activeGameLevelComponentsControllers[i].Init();
            }
        }

        public override void Tick()
        {
            for (int i = 0; i < activeGameLevelComponentsControllers.Count; i++)
            {
                activeGameLevelComponentsControllers[i].Tick();
            }
        }

        public override void FixedTick()
        {
            for (int i = 0; i < activeGameLevelComponentsControllers.Count; i++)
            {
                activeGameLevelComponentsControllers[i].FixedTick();
            }
        }

        public override void LateTick()
        {
            for (int i = 0; i < activeGameLevelComponentsControllers.Count; i++)
            {
                activeGameLevelComponentsControllers[i].LateTick();
            }
        }
    }
}
