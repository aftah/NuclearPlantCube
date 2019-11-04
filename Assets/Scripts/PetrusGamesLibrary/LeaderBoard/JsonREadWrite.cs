//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace PetrusGames.HelperLibrary.Json
{
    public class JsonREadWrite : MonoBehaviour
    {
        public static JsonREadWrite Instance = new JsonREadWrite(); 
        #region SERIALIZED FIELDS
        [Header("Json File To Read Write")]
        [SerializeField] private string jsonFile;
        #endregion

        #region PRIVATE FIELDS
        private List<JsonItem> jsonItems = new List<JsonItem>();
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Read the objects from the Json file and create a list of objects.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<JsonItem> ReadJsonItem(string Path)
        {
            List<JsonItem> items = new List<JsonItem>();

            string st = File.ReadAllText(Application.dataPath + Path);
            

            JsonItem[] jsonsData = PetrusGames.HelperLibrary.Json.JsonHelper.FromJson<JsonItem>(st);
          

            int nr = jsonsData.Length;
            for(var i = 0;i< nr; i++)
            {
                JsonItem item = new JsonItem();
                item.Name = jsonsData[i].Name;
                item.Score = jsonsData[i].Score;
                items.Add(item);
            }
            return items;
        }
        /// <summary>
        /// Write a list of json objects to a string that could be used to write to file. 
        /// </summary>
        /// <param name="jsonItems"></param>
        public string WriteJsonToString(List<JsonItem> jsonItems)
        {
            string tempJson = string.Empty;
            
            tempJson = "{";
            tempJson += '"';
            tempJson += "Items";
            tempJson += '"';
            tempJson += ':';
            tempJson += '[';

            int nr = 0;
            foreach (var item in jsonItems)
            {
               
                tempJson += JsonUtility.ToJson(item);
                if ( nr < jsonItems.Count -1 )
                {
                    tempJson += ",";
                }
                nr++;

            }
            tempJson += ']';

            tempJson += "}";
            //tempJson += JsonUtility.ToJson(jsonItems);
            return tempJson;
        }

        /// <summary>
        /// Write a json string to a json file in the Resources folder
        /// </summary>
        /// <param name="JasonString"></param>
        /// <param name="path"></param>
        public void WriteJsonStringToFile(string JasonString,string path)
        {
            using ( FileStream fs = new FileStream(Application.dataPath + path, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(JasonString);
                }
            }

            #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
            #endif
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

          // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
