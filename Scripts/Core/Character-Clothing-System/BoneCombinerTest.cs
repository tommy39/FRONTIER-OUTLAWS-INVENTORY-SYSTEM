using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Core.CharacterClothing;

namespace IND.Testing
{
    public class BoneCombinerTest : MonoBehaviour
    {
        private BoneCombiner boneCombiner;
        public GameObject itemToAdd;

        private void Start()
        {
            boneCombiner = new BoneCombiner(gameObject);
            boneCombiner.AddLimb(itemToAdd);
        }
    }
}