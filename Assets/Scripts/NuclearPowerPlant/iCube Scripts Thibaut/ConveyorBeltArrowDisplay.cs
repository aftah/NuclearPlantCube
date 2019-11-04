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


namespace PetrusGames
{
    public class ConveyorBeltArrowDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ConveyorBelt conveyorBelt;
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
            conveyorBelt.onChangeDirection += ChangeDirectionHandler;
        }

        private void OnDisable()
        {
            conveyorBelt.onChangeDirection -= ChangeDirectionHandler;
        }

        private void ChangeDirectionHandler(bool obj)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, obj? 0 : 180));
        }
        #endregion


    }
}
