//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.HelperLibrary.TextUtilities
{
    public class DisplayTextCharacterTime : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("Your start string here")]
        [SerializeField] private string startString;
        #endregion
        #region PRIVATE FIELDS
        private string startStringPrivate;
        private string newString;
        private int stringLength;
        private int newStringLength;
        private float _time;
        private bool end;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// returns a string that represents the new partial string,
        /// returns a float to reset the timer ,
        /// returns a bool to let now the stringgrowth is ended.
        /// </summary>
        /// <param name="timeBetweenChar"></param>
        /// <param name="startTime"></param>
        /// <param name="startstring"></param>
        /// <returns>string</returns>
        /// <returns>float</returns>
        /// <return>bool</return>
        public (string, float, bool) SetNewString(float timeBetweenChar, float startTime, string startstring)
        {
            _time = startTime;
            if (_time >= timeBetweenChar)
            {
                _time = 0;
                if (newStringLength < startstring.Length + 1)
                {
                    newString = startstring.Substring(0, newStringLength);
                    newStringLength++;

                }
                else
                {
                    end = true;
                }

            }

            return (newString, _time, end);
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS


        #endregion


    }
}
