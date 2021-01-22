using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Pawns
{
    public class PawnController : IND_Mono
    {
        public List<IND_Mono> pawnComponents = new List<IND_Mono>();


        public override void Init()
        {
            for (int i = 0; i < pawnComponents.Count; i++)
            {
                pawnComponents[i].Init();
            }
        }

        public override void Tick()
        {
            for (int i = 0; i < pawnComponents.Count; i++)
            {
                pawnComponents[i].Tick();
            }
        }
    }
}