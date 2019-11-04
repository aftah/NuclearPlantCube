using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThibautPetit
{
    public class HeatShake : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private HeatInfo heatInfo;
        [SerializeField] private Animator anim;
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

        private void Shake(bool shaking)
        {
            anim.SetBool("isShaking", shaking);
        }

        private void StopOverHeatHandler()
        {
            Shake(false);
        }

        private void OverHeatHandler()
        {
            Shake(true);
        }
        #endregion
    }
}
