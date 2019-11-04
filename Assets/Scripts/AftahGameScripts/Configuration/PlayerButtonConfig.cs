using AftahGames.HelperLibrary;
using System;
using UnityEngine;

namespace AftahGames.NuclearSimulator
{



    public class PlayerButtonConfig : MonoBehaviour
    {


        #region SERIALIZED FIELDS

        [SerializeField] Player player;
        // [SerializeField] private float spawnCoolDown = 2.0f;


        #endregion

        #region PRIVATE FIELDS

        private Input_Manager inputManager;
        // private float spawnCooldownTimer = 0;

        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS



        #endregion

        public event Action<bool, Player, Button> OnSpawnEvent;


        #region EVENTS



        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            inputManager = GetComponent<Input_Manager>();
            // spawnCooldownTimer = 0;


        }

        private void OnEnable()
        {
            inputManager.OnButtonAEvent += InputManager_OnButtonAEvent;
            inputManager.OnButtonBEvent += InputManager_OnButtonBEvent;
            inputManager.OnButtonYEvent += InputManager_OnButtonYEvent;
            inputManager.OnButtonXEvent += InputManager_OnButtonXEvent;

        }

        private void InputManager_OnButtonAEvent(bool obj)
        {

            OnSpawnEvent?.Invoke(obj, player, Button.Button_A);

        }

        private void InputManager_OnButtonBEvent(bool obj)
        {

            OnSpawnEvent?.Invoke(obj, player, Button.Button_B);

        }

        private void InputManager_OnButtonXEvent(bool obj)
        {

            OnSpawnEvent?.Invoke(obj, player, Button.Button_X);
        }

        private void InputManager_OnButtonYEvent(bool obj)
        {

            OnSpawnEvent?.Invoke(obj, player, Button.Button_y);
        }



        private void OnDisable()
        {

            inputManager.OnButtonAEvent -= InputManager_OnButtonAEvent;
            inputManager.OnButtonBEvent -= InputManager_OnButtonBEvent;
            inputManager.OnButtonYEvent -= InputManager_OnButtonYEvent;
            inputManager.OnButtonXEvent -= InputManager_OnButtonXEvent;

        }
        #endregion


    }

}