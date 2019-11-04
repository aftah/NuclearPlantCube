using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThibautPetit
{
    public class HeatDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private Animator anim;
        [SerializeField] private HeatInfo heatInfo;
        #endregion

        #region PRIVATE FIELDS
        private float maxHeat;
        private float targetHeat;
        private float displayedHeat;
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
        private void Start()
        {
            maxHeat = DataManager.Instance.MaxHeat;
        }

        private void Update()
        {
            DisplayHeat();
        }

        private void OnEnable()
        {
            heatInfo.currentHeatUpdate += CurrentHeatUpdate;
        }

        private void OnDisable()
        {
            heatInfo.currentHeatUpdate -= CurrentHeatUpdate;
        }

        private void DisplayHeat()
        {
            displayedHeat = Mathf.SmoothDamp(displayedHeat, targetHeat, ref currentSpeed, smoothTime);
            if (displayedHeat >= 1)
                displayedHeat = 0.99f;
            anim.SetFloat("currentHeat", displayedHeat);
        }

        private void CurrentHeatUpdate(float heat)
        {
            targetHeat = heat / maxHeat;
        }
        #endregion
    }
}
