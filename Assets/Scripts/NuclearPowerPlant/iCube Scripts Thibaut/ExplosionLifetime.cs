//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ExplosionLifetime : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private float lifetime;
        #endregion

        #region PRIVATE FIELDS
        private float currentLifetime;
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
            lifetime = GetComponent<ParticleSystem>().main.duration;
        }

        private void OnEnable()
        {
            currentLifetime = lifetime;
        }

        private void Update()
        {
            currentLifetime -= Time.deltaTime;
            if (currentLifetime < 0)
                gameObject.SetActive(false);
        }
        #endregion


    }
}
