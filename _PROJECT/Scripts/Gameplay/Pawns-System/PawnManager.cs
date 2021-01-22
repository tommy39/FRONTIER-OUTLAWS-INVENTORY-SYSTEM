using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Pawns
{
    public class PawnManager : IND_Mono
    {
        public List<PawnController> pawns = new List<PawnController>();

        public override void Init()
        {
            for (int i = 0; i < pawns.Count; i++)
            {
                pawns[i].Init();
            }
        }

        public override void Tick()
        {
            for (int i = 0; i < pawns.Count; i++)
            {
                pawns[i].Tick();
            }
        }
    }
}