//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class DamageEventManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private HeatInfo[] heatinfos;
        [SerializeField] private ReceiverIDCheck[] idChecks;
        [SerializeField] private EnergyInfo[] energyInfos;
        #endregion

        #region PRIVATE FIELDS
        private float damagePerOverHeatTick;
        private float damagePerWrongElement;
        private float damagePerOverchargeTick;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Start()
        {
            damagePerOverHeatTick = DataManager.Instance.DamagePerOverheatTick;
            damagePerWrongElement = DataManager.Instance.DamagePerWrongElement;
            damagePerOverchargeTick = DataManager.Instance.DamagePerOverheatTick;
        }

        private void Subscribe()
        {
            foreach (var heatinfo in heatinfos)
            {
                heatinfo.overHeatEvent += OverHeatHandler;
            }
            foreach (var idCheck in idChecks)
            {
                idCheck.WrongElementDetected += WrongElementHandler;
            }
            foreach (var energyInfo in energyInfos)
            {
                energyInfo.SurchargingUpdate += SurchargeHandler;
            }
        }

        private void Unsubscribe()
        {
            foreach (var heatinfo in heatinfos)
            {
                heatinfo.overHeatEvent -= OverHeatHandler;
            }
            foreach (var idCheck in idChecks)
            {
                idCheck.WrongElementDetected -= WrongElementHandler;
            }
            foreach (var energyInfo in energyInfos)
            {
                energyInfo.SurchargingUpdate -= SurchargeHandler;
            }
        }

        private void SurchargeHandler()
        {
            HealthManager.instance.TakeDamage(damagePerOverchargeTick);
        }

        private void WrongElementHandler()
        {
            HealthManager.instance.TakeDamage(damagePerWrongElement);
        }

        private void OverHeatHandler()
        {
            HealthManager.instance.TakeDamage(damagePerOverHeatTick);
        }
        #endregion


    }
}
