//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Elements
{
    public class ElementIDScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("This elements ID ")]
        [SerializeField] private elemID ID;
        [SerializeField] private bool isGrabbed;
        #endregion

        #region PRIVATE FIELDS
        private ElementColorScript colorScript;

        #endregion

        #region PUBLIC PROPERTIES
        public elemID ElemID
        {
            get { return ID; }
            set
            {
                ID = value;
                colorScript.SetMaterialToElement();
            }
        }
        public bool IsGrabbed
        {
            get { return isGrabbed; }
            set { isGrabbed = value; }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Awake()
        {
            colorScript = gameObject.GetComponent<ElementColorScript>();
        }
        private void Start()
        {
            colorScript = gameObject.GetComponent<ElementColorScript>();
        }
        #endregion


    }
}
