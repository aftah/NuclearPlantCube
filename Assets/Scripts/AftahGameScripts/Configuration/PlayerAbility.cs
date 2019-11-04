//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.HelperLibrary;
using System;
using UnityEngine;


namespace AftahGames.NuclearSimulator
{
    public class PlayerAbility : MonoBehaviour
    {
       

        #region SERIALIZED FIELDS

        [SerializeField] private AbilitySkill abilities;

        #endregion

        #region PRIVATE FIELDS

        private Input_Manager inputManager;

        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS



        #endregion

        #region EVENTS

        public event Action<bool> OnCoolerEvent;
        public event Action<bool> OnConveyorBelt;
        public event Action<bool> OnWaterGenerator;

        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            inputManager = GetComponent<Input_Manager>();
        }

        private void OnEnable()
        {
            inputManager.OnAbilityEvent += InputManager_OnAbilityEvent;
                
        }

        private void InputManager_OnAbilityEvent(bool obj)
        {
            switch (abilities)
            {
                case AbilitySkill.Cooler:

                    OnCoolerEvent?.Invoke(true);

                    break;
                case AbilitySkill.ConveyorBelt:

                    OnConveyorBelt?.Invoke(true);

                    break;
                case AbilitySkill.WaterGenerator:

                    OnWaterGenerator?.Invoke(true); 

                    break;
                default:
                    break;
            }
        }

       
        private void OnDisable()
        {
            inputManager.OnAbilityEvent -= InputManager_OnAbilityEvent;
        }

        #endregion


    }
}
