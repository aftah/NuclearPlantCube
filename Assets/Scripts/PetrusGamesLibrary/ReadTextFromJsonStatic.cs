//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.Json;
using System.IO;

namespace PetrusGames.HelperLibrary.Json
{
    public static class ReadTextFromJsonStatic
    {
        #region PRIVATE FIELDS
        #endregion


        #region PUBLIC FUNCTIONS

        /// <summary>
        /// get string from json file with use of parameter file name plus extention (example.json) 
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <returns></returns>
        public static string GetStringFromJson(string jsonFile)
        {
            string st = string.Empty;
            st = Application.dataPath + "/Resources/" + jsonFile;
            string newString = File.ReadAllText(st);
            jsonText[] _jsonText = JsonHelper.FromJson<jsonText>(newString);
            st = _jsonText[0].Text;


            return st;
        }

        /// <summary>
        /// get string from json file with use of parameter file name plus extention (example.json),
        /// and the file location (/Resources/) 
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <param name="FileLocation"></param>
        /// <returns></returns>
        public static string GetStringFromJson(string jsonFile, string FileLocation)
        {
            string st = string.Empty;
            st = Application.dataPath + FileLocation + jsonFile;
            string newString = File.ReadAllText(st);
            jsonText[] _jsonText = JsonHelper.FromJson<jsonText>(newString);
            st = _jsonText[0].Text;


            return st;
        }
        #endregion


    }
}
