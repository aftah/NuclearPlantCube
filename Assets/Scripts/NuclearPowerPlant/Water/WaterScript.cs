//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Water
{
    public class WaterScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.transform.gameObject.tag == "Fire")
            {
                collision.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            if(collision.transform.gameObject.tag == "Floor")
            {
                this.gameObject.SetActive(false);
            }
        }
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
