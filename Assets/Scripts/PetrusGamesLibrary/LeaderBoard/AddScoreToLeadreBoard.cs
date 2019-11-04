//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.Json;

namespace PetrusGames.HelperLibrary.LeaderBoard
{
    public class AddScoreToLeadreBoard : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("File location string (info only!!!)")]
        [SerializeField] private string JsonFileLocation = "/Resources/LeaderBoard.json";
        #endregion

        #region PRIVATE FIELDS
        private List<JsonItem> jsonItems = new List<JsonItem>();
        #endregion

        #region PUBLIC PROPERTIES

        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// adds a new score to the json file
        /// this function uses a data path from the path parameter
        /// </summary>
        /// <param name="item"></param>
        /// <param name="path"></param>
        public void AddNewScoreToLeaderBoardJson(JsonItem item,string path)
        {
            if (path == string.Empty) { path = JsonFileLocation; }
            else
            { // for info only in editor
                JsonFileLocation = path;
            }
            // write item to string
            jsonItems = JsonREadWrite.Instance.ReadJsonItem(path);
            jsonItems.Add(item);
            string itemsInString = JsonREadWrite.Instance.WriteJsonToString(jsonItems);
            JsonREadWrite.Instance.WriteJsonStringToFile(itemsInString, path);
        }
        /// <summary>
        /// adds a new score to the json file
        /// this function uses the default data path /Resources/LeaderBoard.json for saving the json file
        /// </summary>
        /// <param name="item"></param>
        public void AddNewScoreToLeaderBoardJson(JsonItem item)
        {
            // write item to string
            jsonItems = JsonREadWrite.Instance.ReadJsonItem(JsonFileLocation);
            jsonItems.Add(item);
            string itemsInString = JsonREadWrite.Instance.WriteJsonToString(jsonItems);
            JsonREadWrite.Instance.WriteJsonStringToFile(itemsInString, JsonFileLocation);
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

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
