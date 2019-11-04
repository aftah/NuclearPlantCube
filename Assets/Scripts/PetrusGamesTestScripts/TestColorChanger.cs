//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Elements.Test
{
    public class TestColorChanger : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private GameObject element;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public void ChangeMaterialRandom()
        {
            element.GetComponent<ElementColorScript>().SetRandomColor();

        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void OnEnable()
        {
            element.GetComponent<ElementColorScript>().SetRandomColor();
        }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
