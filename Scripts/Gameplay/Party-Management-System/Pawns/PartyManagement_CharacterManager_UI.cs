using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Party;
using TMPro;
using IND.Gameplay.Inventory.UI;

namespace IND.Gameplay.PartyMangement.UI
{
    public class PartyManagement_CharacterManager_UI : IND_Mono
    {
        [SerializeField] protected PartyController playerParty;
        [SerializeField] protected Transform charactersList;
        [SerializeField] protected GameObject selectableCharacterPrefab;
        [SerializeField] protected TextMeshProUGUI characterNameText;
        [SerializeField] protected TextMeshProUGUI characterTitleText;
        [SerializeField] protected TextMeshProUGUI characterExperienceText;

        private List<PartyManagement_SelectableCharacter_UI> createdSelectableCharacters = new List<PartyManagement_SelectableCharacter_UI>();

        public PartyManagement_SelectableCharacter_UI selectedCharacter;
        [SerializeField] protected InventoryPawn_UI pawnInventory;

        public override void Init()
        {
            if (setupPartyWindowOnEditorStart == true)
            {
                EditorStart();
            }
        }

        public override void Tick()
        {

        }

        [SerializeField] protected bool setupPartyWindowOnEditorStart = true;

        public void OnCharacterSelected(PartyManagement_SelectableCharacter_UI character)
        {
            OnDeselectCharacter();
            selectedCharacter = character;
            characterNameText.text = character.characterInfo.pawnName;
            characterTitleText.text = character.characterInfo.pawnTitle;
            characterExperienceText.text = "Level " + character.characterInfo.pawnLevel + " " + character.characterInfo.pawnCurrentExperience + " /5000";
            pawnInventory.SetupNewSelectionInventory(character.characterInfo.inventory);
        }


        public void OnDeselectCharacter()
        {

        }

        private void EditorStart()
        {
            //Delete any existing items
            PartyManagement_SelectableCharacter_UI[] existingCharacters = charactersList.GetComponentsInChildren<PartyManagement_SelectableCharacter_UI>();
            for (int i = 0; i < existingCharacters.Length; i++)
            {
                Destroy(existingCharacters[i].gameObject);
            }

            //Create New Items
            for (int i = 0; i < playerParty.partyCharacters.Count; i++)
            {
                PartyManagement_SelectableCharacter_UI selectablePartyMember = Instantiate(selectableCharacterPrefab, charactersList).GetComponent<PartyManagement_SelectableCharacter_UI>();
                selectablePartyMember.SetupCharacter(playerParty.partyCharacters[i]);
                createdSelectableCharacters.Add(selectablePartyMember);
            }

            //Select First Item
            createdSelectableCharacters[0].SelectCharacter();
        }

        public static PartyManagement_CharacterManager_UI singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}