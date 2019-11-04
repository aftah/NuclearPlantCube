//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.Json;
using System.Linq;

namespace PetrusGames.HelperLibrary.LeaderBoard
{
    public class SortListFromLeaderBoard : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        private List<JsonItem> jsonItems = new List<JsonItem>();
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public List<JsonItem> GetItemsSortedFromJson()
        {
            var Items = new List<JsonItem>();
            Items = GetItemsFromJson();
            var sortedItems = Items.OrderBy(a => a.Score).ToList();
            return sortedItems;
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

    private List<JsonItem> GetItemsFromJson()
        {
           var jItems = PetrusGames.HelperLibrary.Json.JsonREadWrite.Instance.ReadJsonItem("/Resources/LeaderBoard.json");

            return jItems;
        }
        #endregion


    }
}
