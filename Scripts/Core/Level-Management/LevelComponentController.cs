using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core.GameLevels;

namespace IND.Core.LevelManagement
{
    public class LevelComponentController : IND_Mono
    {
        [Required]public GameLevel gameLevel;
        public List<IND_Mono> components = new List<IND_Mono>();
        public override void Init()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Init();
            }
        }

        public override void Tick()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Tick();
            }
        }

        public override void FixedTick()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].FixedTick();
            }
        }

        public override void LateTick()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].LateTick();
            }
        }


    }
}