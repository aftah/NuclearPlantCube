//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace PetrusGames
{
    public class HealthDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        public static HealthDisplay instance;
        public TextMeshPro[] tmp;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public void UpdateHealth(float currentHealth)
        {
            foreach (var text in tmp)
            {
                text.text = currentHealth.ToString();
            }
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS 
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        #endregion


    }
}
