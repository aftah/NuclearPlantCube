//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Fire
{
    public class FireManagerScript : MonoBehaviour
    {
        public static FireManagerScript Instance = new FireManagerScript();
        #region SERIALIZED FIELDS
        [Header("Current Fire Dammage")]
        [SerializeField] private int totalFireDammage;
        [Header("Set time for the damage event  ")]
        [SerializeField] private float timeBetweenDamage;
        [Header(" If this is Singleton set true")]
        [SerializeField] private bool IsSingleton;
        #endregion

        #region PRIVATE FIELDS
        private float tBD;
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Add Damage to the reactor
        /// </summary>
        public int TotalFireDamageAdd
        {
            set { totalFireDammage += value; }

        }
        /// <summary>
        /// remove damage 
        /// </summary>
        public int TotalFireDamageRemove
        {
            set { totalFireDammage -= value; }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<int> FireDamageEvent;
        #endregion

        #region PRIVATE FUNCTIONS
        
    void Start()
    {
            // set the timer to the inspector value
            tBD = timeBetweenDamage;
            // if is singleton
            if (Instance != null)
             {
                Destroy(this);
             }
            else
            {
                if (IsSingleton)
                {
                    Instance = this;
                }
            }
            
    }
        
    void Update()
    {
            tBD -= Time.deltaTime;

            if(tBD < 0)
            {
                // reset the timer to the original value
                tBD = timeBetweenDamage;
                // launch the damage event
                FireDamageEvent?.Invoke(totalFireDammage);
            }
    }
        #endregion


    }
}
