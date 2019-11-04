//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Fire.Test
{
    public class FireTestScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("View the damage done by fire")]
        [SerializeField] private int fireDamage;
        [Header("View the Total Damage Done By Fire")]
        [SerializeField] private int totalDamageDone;
        [Header("Place The FireManager Object Here")]
        [SerializeField] private GameObject fireManager;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        private void Awake()
        {
            fireManager.GetComponent<FireManagerScript>().FireDamageEvent += AddDamageListener;
        }


        #endregion

        #region PRIVATE FUNCTIONS
        private void AddDamageListener(int obj)
        {
            fireDamage = obj;
            totalDamageDone += obj;
        }
     #endregion


    }
}
