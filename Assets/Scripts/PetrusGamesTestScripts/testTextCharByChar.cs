//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.TextUtilities;
using UnityEngine.UI;

namespace PetrusGames.Test.TextUtilities
{
    public class testTextCharByChar : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private TMPro.TextMeshPro textObject;
        [SerializeField] private float TimeBetweenCharacters = 0.1f;
        #endregion

        #region PRIVATE FIELDS
        private DisplayTextCharacterTime textCharacterTime = new DisplayTextCharacterTime();
        private float T2;
        private bool isEnded;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

          // Start is called before the first frame update
    void Start()
    {
            isEnded = false;
            textObject.text = "";
            T2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
            if (isEnded == false)
            {
                T2 += Time.deltaTime;
                var output = textCharacterTime.SetNewString(TimeBetweenCharacters, T2, "Hello world and other places,");
                textObject.text = output.Item1;
                T2 = output.Item2;
                isEnded = output.Item3;
            }
    }
        #endregion


    }
}
