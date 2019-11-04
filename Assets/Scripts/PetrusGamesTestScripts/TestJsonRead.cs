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
    public class TestJsonRead : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        private List<JsonItem> jsonItems = new List<JsonItem>();
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
            var j = new PetrusGames.HelperLibrary.LeaderBoard.SortListFromLeaderBoard();
            jsonItems = j.GetItemsSortedFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
