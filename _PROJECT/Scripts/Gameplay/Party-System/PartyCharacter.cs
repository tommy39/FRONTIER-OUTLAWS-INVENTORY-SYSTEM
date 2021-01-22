using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Inventory;

namespace IND.Gameplay.Party
{
    [System.Serializable]
    public class PartyCharacter
    {
        [FoldoutGroup("Pawn")]
        public string pawnName;
        [FoldoutGroup("Pawn")] public string pawnTitle;
        [FoldoutGroup("Pawn")] public Sprite portraitIcon;
        [FoldoutGroup("Pawn")] public int pawnLevel;
        [FoldoutGroup("Pawn")] public int pawnCurrentExperience;

        [FoldoutGroup("Pawn")] public PartyCharacterInventory inventory;
    }
}