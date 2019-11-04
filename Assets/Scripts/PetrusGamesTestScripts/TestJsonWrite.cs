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
    public class TestJsonWrite : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        private List<JsonItem> jsonItems;
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
            jsonItems = new List<JsonItem>();
            jsonItems.Add(new JsonItem { Name = "ward", Score = 123 });
            jsonItems.Add(new JsonItem { Name = "aftah", Score = 4658 });
            jsonItems.Add(new JsonItem { Name = "tibaut", Score = 654 });
            jsonItems.Add(new JsonItem { Name = "stephane", Score = 548 });
            jsonItems.Add(new JsonItem { Name = "dingo", Score = 4569 });
            jsonItems.Add(new JsonItem { Name = "your mama", Score = 4568 });
            jsonItems.Add(new JsonItem { Name = "your papa", Score = 5646 });
            jsonItems.Add(new JsonItem { Name = "the other guy", Score = 874 });
            jsonItems.Add(new JsonItem { Name = "tester one", Score = 4 });
            jsonItems.Add(new JsonItem { Name = "oh nooooo", Score = 49 });
            jsonItems.Add(new JsonItem { Name = "satan", Score = 66666666 });
            jsonItems.Add(new JsonItem { Name = "god", Score = 777777 });
            string st = JsonREadWrite.Instance.WriteJsonToString(jsonItems);
            JsonREadWrite.Instance.WriteJsonStringToFile(st, "/Resources/LeaderBoard.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
