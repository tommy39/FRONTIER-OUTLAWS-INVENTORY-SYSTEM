using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using UnityEngine.UI;
using IND.Gameplay.Party;

namespace IND.Gameplay.PartyMangement.UI
{
    public class PartyManagement_SelectableCharacter_UI : IND_Mono
    {
        [SerializeField] protected Image portraitIcon;
        [SerializeField] protected Button button;
        public PartyCharacter characterInfo;

        public void SetupCharacter(PartyCharacter character)
        {
            button.onClick.AddListener(SelectCharacter);
            portraitIcon.sprite = character.portraitIcon;
            characterInfo = character;
        }

        public void SelectCharacter()
        {
            if (PartyManagement_CharacterManager_UI.singleton.selectedCharacter == this)
                return;

            PartyManagement_CharacterManager_UI.singleton.OnCharacterSelected(this);
        }
    }
}