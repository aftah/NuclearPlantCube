//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.HelperLibrary.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Water.Test
{
    public class PushForWater : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("WaterSpawner object")]
        [SerializeField] private GameObject Spawner;
        [Header("object to spawn")]
        [SerializeField] private GameObject ObjectToSpawn;
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

          // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawner.GetComponent<ObjectSpawner>().SpawnObjectFromPool(ObjectToSpawn, new Vector3(1, 3, 1),Quaternion.Euler(0,0,0));
            }
    }
        #endregion


    }
}
