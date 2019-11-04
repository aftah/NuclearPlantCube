//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PetrusGames.NuclearPlant.Objects.Elements.Test;

namespace PetrusGames.HelperLibrary.UnityEditor.Button
{
    [CustomEditor(typeof(TestColorChanger))]
    public class ButtonInEditor : Editor
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            TestColorChanger testColorChanger = (TestColorChanger)target;
            if (GUILayout.Button("Change Material Random"))
            {
                testColorChanger.ChangeMaterialRandom();
            }
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        #endregion


    }
}
