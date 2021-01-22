using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IND.Core.Inputs;
using IND.Core.LevelManagement;

namespace IND.Core.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        private LevelManager levelManager;
        private InputManager inputManager;
        private InputManagerResetter inputManagerResetter;

        void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();
            inputManager = FindObjectOfType<InputManager>();
            inputManagerResetter = FindObjectOfType<InputManagerResetter>();

            inputManager.Init();
            levelManager.Init();
            inputManagerResetter.Init();
        }
        void Update()
        {
            inputManager.Tick();
            levelManager.Tick();
            inputManagerResetter.Tick();
        }

        private void FixedUpdate()
        {
            inputManager.FixedTick();
            levelManager.FixedTick();
            inputManagerResetter.FixedTick();
        }

        private void LateUpdate()
        {
            inputManager.LateTick();
            levelManager.LateTick();
            inputManagerResetter.LateTick();
        }

        public void OnLocationChanged()
        {
            levelManager = FindObjectOfType<LevelManager>();
            levelManager.Init();
        }

        private IEnumerator ReEnable()
        {
            yield return 0;
            this.enabled = true;
            Start();
        }
    }
}