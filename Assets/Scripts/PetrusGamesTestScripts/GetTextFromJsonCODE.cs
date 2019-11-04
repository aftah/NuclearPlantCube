//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.Json;

namespace PetrusGames.Test.Json
{
    public class GetTextFromJsonCODE : MonoBehaviour
    {
        #region SERIALIZED FIELDS
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

          // Start is called before the first frame update
    void Start()
    {
            string st1 = ReadTextFromJson.SingletonInstance.GetStringFromJson("Text.json");
            Debug.Log(st1);
            string st2 = ReadTextFromJson.SingletonInstance.GetStringFromJson("Text.json", "/Resources/");
            Debug.Log(st2);

            string st3 = ReadTextFromJsonStatic.GetStringFromJson("Text.json");
            Debug.Log(st3);
            string st4 = ReadTextFromJsonStatic.GetStringFromJson("Text.json", "/Resources/");
            Debug.Log(st4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
