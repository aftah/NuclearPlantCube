//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using PetrusGames.HelperLibrary.Json;


namespace PetrusGames.HelperLibrary.Json
{
    public  class ReadTextFromJson : MonoBehaviour
    {
        public static ReadTextFromJson SingletonInstance = new ReadTextFromJson();
        #region SERIALIZED FIELDS
        [Header("When used from unity editor add json file and folder here")]
        [SerializeField] private string FileName = "Text.json";
        [SerializeField] private string fileLocation = "/Resources/";
        [Header("Add textbox here if used with unity editor")]
        [SerializeField] private Text TextBox;
        #endregion

        #region PRIVATE FIELDS
        private string location;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Return a string with the text from a json file located in /Resources/
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <returns></returns>
        public string GetStringFromJson(string jsonFile)
        {
            string st = string.Empty;
            st = Application.dataPath + "/Resources/" + jsonFile;
            string newString = File.ReadAllText(st);
            jsonText[] _jsonText = JsonHelper.FromJson<jsonText>(newString);
            st = _jsonText[0].Text;


            return st;
        }
        /// <summary>
        /// return a string from a json file in the location from the parameter filelocation
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <param name="FileLocation"></param>
        /// <returns></returns>
        public string GetStringFromJson(string jsonFile,string FileLocation)
        {
            string st = string.Empty;
            st = Application.dataPath + FileLocation + jsonFile;
            string newString = File.ReadAllText(st);
            jsonText[] _jsonText = JsonHelper.FromJson<jsonText>(newString);
            st = _jsonText[0].Text;


            return st;
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void SetTextToTextBox()
        {
            string st = File.ReadAllText(location);
            jsonText[] _jsonText = JsonHelper.FromJson<jsonText>(st);
            TextBox.text = _jsonText[0].Text;
        }
        // Start is called before the first frame update
        void Start()
    {
         
            SetTextToTextBox();
    }
        private void Awake()
        {
            location = Application.dataPath + fileLocation + FileName;


        }
        // Update is called once per frame
        void Update()
    {
        
    }
        #endregion


    }
}
