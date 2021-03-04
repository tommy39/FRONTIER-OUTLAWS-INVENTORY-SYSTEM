using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;

namespace IND.Gameplay.Items
{
    public class ItemController : IND_Mono
    {
        [InlineEditor] public ItemData data;
        public GameObject createdPrefab;

        public override void Init()
        {

        }

        public override void Tick()
        {

        }
    }
}