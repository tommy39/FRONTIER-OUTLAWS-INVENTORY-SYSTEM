using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using IND.Core;
using IND.Gameplay.Items;
using IND.Gameplay.Party;
using IND.Core.CharacterClothing;
using IND.Gameplay.Inventory.UI;

namespace IND.Gameplay.Inventory
{
    /// <summary>Controller For Rendering a character in the Inventory UI with the correct equipment</summary>
    public class CharacterRenderInventoryController : IND_Mono
    {
        public ItemController headEquipment;
        private BoneCombiner boneCombiner;
        public PartyCharacterInventory charInv;

        public GameObject createdHeadArmor;
        public List<GameObject> createdBodyArmor = new List<GameObject>();
        public GameObject createdRightHandWeapon;
        public GameObject createdLeftHandWeapon;

        [SerializeField] protected Transform rightHandTrans;
        [SerializeField] protected Transform leftHandTrans;

        /// <summary>Called When a new party character is selected</summary>
        public void OnSpawn(PartyCharacterInventory partyChar)
        {
            boneCombiner = new BoneCombiner(gameObject);
            charInv = partyChar;
            Animator anim = GetComponent<Animator>();
            anim.Play("idle");
        }

        /// <summary>Adds a 3d clothing item to the character and then combines the mesh/bones</summary>
        public void AddLimbModel(GameObject itemToAdd, InventorySlotType_UI slotType)
        {
            boneCombiner.AddLimb(itemToAdd);
            switch (slotType)
            {
                case InventorySlotType_UI.head:
                    createdHeadArmor = boneCombiner.createdGameObject;
                    break;
                case InventorySlotType_UI.body:
                    createdBodyArmor.Add(boneCombiner.createdGameObject);
                    break;
            }
        }

        /// <summary>Removes a 3d clothing item from the character</summary>
        public void RemoveLimbModel(InventorySlotType_UI slotType)
        {
            switch (slotType)
            {
                case InventorySlotType_UI.head:
                    if (createdHeadArmor != null)
                    {
                        Destroy(createdHeadArmor);
                    }
                    break;
                case InventorySlotType_UI.body:
                    if (createdBodyArmor != null)
                    {
                        for (int i = 0; i < createdBodyArmor.Count; i++)
                        {
                            Destroy(createdBodyArmor[i]);
                        }
                    }
                    break;
            }
        }

        public void AddWeaponModel(GameObject itemToAdd, WeaponHandlingType weaponHandlingType, bool isRightHand)
        {
            GameObject geo = Instantiate(itemToAdd);

            if (isRightHand == true)
            {
                geo.transform.SetParent(rightHandTrans);
            }
            else
            {
                geo.transform.SetParent(leftHandTrans);
            }

            geo.transform.localScale = Vector3.one;

            switch (weaponHandlingType)
            {
                case WeaponHandlingType.OneHanded:
                    if (isRightHand == true)
                    {
                        createdRightHandWeapon = geo;
                        WeaponItemData itemWeapon = charInv.rightHandWeaponItem.itemData as WeaponItemData;
                        PlayWeaponPoseAnimation(itemWeapon.inventoryRenderPreviewAnimName) ;
                        geo.transform.localPosition = itemWeapon.rightHandLocalPos;
                        geo.transform.localRotation = itemWeapon.rightHandLocalRot;
                    }
                    else
                    {
                        createdLeftHandWeapon = geo;

                        //Get Weapon Data
                        WeaponItemData itemWeapon = charInv.leftHandWeaponItem.itemData as WeaponItemData;
                        PlayWeaponPoseAnimation(itemWeapon.inventoryRenderPreviewAnimName);
                        geo.transform.localPosition = itemWeapon.leftHandLocalPos;
                        geo.transform.localRotation = itemWeapon.leftHandLocalRot;
                    }
                    break;
                case WeaponHandlingType.TwoHanded:
                    createdRightHandWeapon = geo;
                    WeaponItemData twoHandedWeapon = charInv.rightHandWeaponItem.itemData as WeaponItemData;
                    PlayWeaponPoseAnimation(twoHandedWeapon.inventoryRenderPreviewAnimName);

                    geo.transform.localPosition = twoHandedWeapon.rightHandLocalPos;
                    geo.transform.localRotation = twoHandedWeapon.rightHandLocalRot;

                    if (createdLeftHandWeapon != null)
                    {
                        DestroyWeaponModel(false);
                    }
                    break;
            }
        }

        public void DestroyWeaponModel(bool isRightHand)
        {
            if (isRightHand == false)
            {
                Destroy(createdLeftHandWeapon);
            }
            else
            {
                Destroy(createdRightHandWeapon);
            }

            if (createdRightHandWeapon == null && createdLeftHandWeapon == null)
            {
                PlayWeaponPoseAnimation("idle");
            }
        }

        /// <summary>Plays a specific animation string based on what type of weapon is equipped</summary>
        public void PlayWeaponPoseAnimation(string animName)
        {
            Animator anim = GetComponent<Animator>();
            anim.Play(animName);
        }
    }
}