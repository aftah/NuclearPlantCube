//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class HealthManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS     
        private float maxHealth;
        private float currentHealth;
        #endregion

        #region PUBLIC PROPERTIES
        public static HealthManager instance;

        public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

        public float CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                currentHealth = value;
                HealthDisplay.instance.UpdateHealth(currentHealth);
            }
        }

        #endregion

        #region PUBLIC FUNCTIONS
        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void HealthCheck()
        {
            if (CurrentHealth <= 0)
            {
                //do something                
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

        private void Start()
        {
            MaxHealth = DataManager.Instance.Health;
            CurrentHealth = MaxHealth;
        }


        #endregion


    }
}
