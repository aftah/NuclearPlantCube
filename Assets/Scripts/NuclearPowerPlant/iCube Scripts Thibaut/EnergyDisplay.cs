using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThibautPetit
{
    public class EnergyDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private EnergyInfo energyInfo;
        [SerializeField] private Animator anim;
        #endregion

        #region PRIVATE FIELDS
        private float maxEnergy;
        private float targetEnergy;
        private float displayeEnergy;
        private float currentSpeed = 1f;
        private float smoothTime = 1f;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            energyInfo.EnergyUpdate += EnergyUpdateHandler;
        }

        private void Start()
        {            
            maxEnergy = DataManager.Instance.MaxEnergy;
        }

        private void OnDisable()
        {
            energyInfo.EnergyUpdate -= EnergyUpdateHandler;
        }

        private void Update()
        {
            DisplayeEnergy();
        }

        private void DisplayeEnergy()
        {
            displayeEnergy = Mathf.SmoothDamp(displayeEnergy, targetEnergy, ref currentSpeed, smoothTime);
            if (displayeEnergy >= 1)
                displayeEnergy = 0.99f;
            anim.SetFloat("CurrentEnergy", displayeEnergy);
        }

        private void EnergyUpdateHandler(float currentEnergy)
        {
            targetEnergy = currentEnergy / maxEnergy;
        }
        #endregion
    }
}
