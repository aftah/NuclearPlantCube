//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.Json;
using UnityEngine.UI;
using System.Linq;
namespace PetrusGames.HelperLibrary.LeaderBoard
{
    public class FillLeaderBoard : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("List of Leaderboard items")]
        [SerializeField] private List<GameObject> LeaderBoardItems;
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
            var max = jsonItems.Count -1 ;
            for (var i =0; i < 10; i++)
            {
                var nr = max - i;
                LeaderBoardItems[i].GetComponentInChildren<Text>().text = jsonItems[nr].Name;
                LeaderBoardItems[i].transform.Find("SCORE").GetComponent<Text>().text = jsonItems[nr].Score.ToString();
            }
        }

   
        #endregion


    }
}
