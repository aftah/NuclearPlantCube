//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PetrusGames.NuclearPlant.Objects.Elements
{
    public class GlowRegulator : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private float minGlow;
        [SerializeField] private float maxGlow;
        [SerializeField] private float smoothTimer;
        [SerializeField] private PostProcessVolume ppv;
        #endregion

        #region PRIVATE FIELDS
        private Bloom bloom;
        private float currentGlow;
        private float currentVelocity = 1f;
        private bool isGlowingUp = true;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Start()
        {
            ppv.profile.TryGetSettings(out bloom);
        }

        private void Update()
        {
            UpdateCurrentGlow();
            CheckCurrentGlow();
            UpdateGlowValue();
        }

        private void UpdateGlowValue()
        {
            bloom.intensity.value = currentGlow;
        }

        private void CheckCurrentGlow()
        {
            if (currentGlow >= maxGlow -0.1)
                isGlowingUp = false;
            if (currentGlow <= minGlow + 0.1)
                isGlowingUp = true;
        }

        private void UpdateCurrentGlow()
        {
            currentGlow = Mathf.SmoothDamp(currentGlow, (isGlowingUp ? maxGlow : minGlow), ref currentVelocity, smoothTimer);
                // Mathf.Lerp(currentGlow, isGlowingUp ? maxGlow : minGlow, smoothTimer);
               // (currentGlow, (isGlowingUp ? maxGlow : minGlow), ref currentVelocity, smoothTimer);
        }

        #endregion


    }
}
