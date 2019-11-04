using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.NuclearPlant.Managers.Data;


namespace ThibautPetit
{
    // Abonner le score et la santé de la centrale à SurchargingUpdate et à GoodEnergyRangeUpdate
    public class EnergyInfo : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ReceiverIDCheck iDCheck;
        #endregion

        #region PRIVATE FIELDS
        private float energyGainPerGoodElement;
        private float energyLossPerWrongElement;
        private float energyMaxThreshold;
        private float energyMinThreshold;
        private float energyLossPerSecond;
        private float maxEnergy;
        private float currentEnergy;
        private bool isInRange = false;
        private float goodRangeTick;
        private bool isSurcharging = false;
        private float surchargeTick;
        #endregion

        #region PUBLIC PROPERTIES
        public float CurrentEnergy
        {
            get { return currentEnergy; }
            private set
            {
                currentEnergy = value;
                EnergyCheck();
                EnergyUpdate?.Invoke(currentEnergy);
            }
        }

        public float MaxEnergy { get => maxEnergy; }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<float> EnergyUpdate;
        public event Action SurchargingUpdate;
        public event Action GoodEnergyRangeUpdate;
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            iDCheck.WrongElementDetected += WrongElementHandler;
            iDCheck.CorrectElementDetected += CorrectElementHandler;
        }

        private void OnDisable()
        {
            iDCheck.WrongElementDetected -= WrongElementHandler;
            iDCheck.CorrectElementDetected -= CorrectElementHandler;
        }

        private void CorrectElementHandler()
        {
            CurrentEnergy += energyGainPerGoodElement;
        }

        private void WrongElementHandler()
        {
            CurrentEnergy -= energyLossPerWrongElement;
        }

        void Start()
        {
            energyGainPerGoodElement = DataManager.Instance.EnergyGainPerGoodElement;
            energyLossPerWrongElement = DataManager.Instance.EnergyLossPerWrongElement;
            energyMaxThreshold = DataManager.Instance.EnergyMaxThreshold;
            energyMinThreshold = DataManager.Instance.EnergyMinThreshold;
            energyLossPerSecond = DataManager.Instance.EnergyLossPerSecond;
            maxEnergy = DataManager.Instance.MaxEnergy;
            goodRangeTick = DataManager.Instance.GoodRangeTick;
            surchargeTick = DataManager.Instance.SurchargeTick;
            StartCoroutine(LoseEnergy());
        }

        void Update()
        {
            if (isInRange)
                GoodRangeUpdate();

            if (isSurcharging)
                SurchargeUpdate();
        }

        private void SurchargeUpdate()
        {
            surchargeTick -= Time.deltaTime;
            if (surchargeTick <= 0)
            {
                SurchargingUpdate?.Invoke();
                surchargeTick = 1f;
            }
        }

        private void GoodRangeUpdate()
        {
            goodRangeTick -= Time.deltaTime;
            if (goodRangeTick <= 0)
            {
                GoodEnergyRangeUpdate?.Invoke();
                goodRangeTick = 1f;
            }
        }

        private IEnumerator LoseEnergy()
        {
            CurrentEnergy -= energyLossPerSecond;
            yield return new WaitForSeconds(1);
            StartCoroutine(LoseEnergy());
        }

        private void EnergyCheck()
        {
            if (currentEnergy < 0)
                CurrentEnergy = 0;

            if (currentEnergy > MaxEnergy)
                CurrentEnergy = MaxEnergy;

            if (currentEnergy < energyMinThreshold)
            {
                isInRange = false;
                isSurcharging = false;
            }

            if (currentEnergy >= energyMinThreshold && currentEnergy <= energyMaxThreshold)
            {
                isInRange = true;
                isSurcharging = false;
            }

            if (currentEnergy > energyMaxThreshold)
            {
                isInRange = false;
                isSurcharging = true;
            }
        }
        #endregion
    }
}
