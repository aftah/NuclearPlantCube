//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;
using AftahGames.NuclearSimulator;


namespace PetrusGames
{
    public class HeatDistortionDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private HeatInfo heatInfo;
        [SerializeField] private GameObject heatDistortion;
        #endregion

        #region PRIVATE FIELDS
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
            heatInfo.overHeatEvent += OverHeatHandler;
            heatInfo.stopOverHeatEvent += StopOverHeatHandler;
        }

        private void OnDisable()
        {
            heatInfo.overHeatEvent -= OverHeatHandler;
            heatInfo.stopOverHeatEvent -= StopOverHeatHandler;
        }

        private void StopOverHeatHandler()
        {
            if (heatDistortion.activeSelf)
            {
                //Aftah Put Sound
                SoundManager.Instance.StopSound("EnergieDistorsion");
                heatDistortion.SetActive(false);
            }
        }

        private void OverHeatHandler()
        {
            if (!heatDistortion.activeSelf)
            {
                //aftah put sound
                SoundManager.Instance.PlaySound("EnergieDistorsion"); 
                heatDistortion.SetActive(true);
            }
        }
        #endregion
    }
}
