using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using PetrusGames.NuclearPlant.Objects.Elements;



namespace ThibautPetit
{
    public class ReceiverIDCheck : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        [SerializeField] private elemID requiredID;

        #endregion

        #region PUBLIC PROPERTIES
        public elemID RequiredID { get => requiredID; }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action CorrectElementDetected;
        public event Action WrongElementDetected;
        #endregion

        #region PRIVATE FUNCTIONS

        void Start()
        {
            ResetRequiredID();
        }

        private void ResetRequiredID()
        {
            requiredID = GetRandomRequiredID();
        }

        private elemID GetRandomRequiredID()
        {
            return (elemID)UnityEngine.Random.Range(0, Enum.GetNames(typeof(elemID)).Length);
            
        }

        private void CompareElements(Collider element)
        {
            elemID ElementID = element.GetComponent<ElementIDScript>().ElemID;
            if (RequiredID == ElementID)
            {
                CorrectElementDetected.Invoke();
            }
            else
            {
                WrongElementDetected.Invoke();
            }

            //Destroy(element.gameObject);
            element.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                CompareElements(other);
                ResetRequiredID();
            }
        }
        #endregion
    }
}
