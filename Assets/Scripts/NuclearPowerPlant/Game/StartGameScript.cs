//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PetrusGames
{
    public class StartGameScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("Scene to Go to")]
        [SerializeField] private string GameName;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public void GoToStartScene()
        {
            SceneManager.LoadScene(GameName);
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        /// <summary>
        /// temp input till inputmanager is created!!!!!!!!!!
        /// </summary>
        private void CheckButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(GameName);
            }
        }
          // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            CheckButtonPressed();
    }
        #endregion


    }
}
