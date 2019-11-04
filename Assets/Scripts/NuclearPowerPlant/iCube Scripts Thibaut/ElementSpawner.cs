//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using PetrusGames.HelperLibrary;
using PetrusGames.NuclearPlant.Managers.Data;
using PetrusGames.NuclearPlant.Objects.Elements;
using System.Collections.Generic;
using UnityEngine;

namespace PetrusGames.NuclearPlant.Managers.Elements
{
    public class ElementSpawner : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Input_Manager inputManager;
        [SerializeField] private GameObject element;
        [SerializeField] private List<elemID> elemIDs;
        [SerializeField] private bool canSpawn;
        [SerializeField] private Animator cooldownAnim;
        [SerializeField] private Animator openAnim;

        #endregion

        #region PRIVATE FIELDS
        private float spawnTimer, tempTimer;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Start()
        {
            spawnTimer = DataManager.Instance.ElementSpawnTimer;
            tempTimer = spawnTimer;
        }
        private void Update()
        {
            CountDown();
            UpdateAnim();
        }

        private void UpdateAnim()
        {
            float currentAnim = 1 - (spawnTimer / tempTimer);
            if (currentAnim >= 1)
            {
                currentAnim = 0.99f;
            }

            cooldownAnim.SetFloat("Timer", currentAnim);
        }

        private void CountDown()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0) { canSpawn = true; }
        }

        private void OnEnable()
        {
            inputManager.OnButtonAEvent += ButtonAEventHandler;
            inputManager.OnButtonBEvent += ButtonBEventHandler;
            inputManager.OnButtonXEvent += ButtonXEventHandler;
            inputManager.OnButtonYEvent += ButtonYEventHandler;
        }

        private void OnDisable()
        {
            inputManager.OnButtonAEvent -= ButtonAEventHandler;
            inputManager.OnButtonBEvent -= ButtonBEventHandler;
            inputManager.OnButtonXEvent -= ButtonXEventHandler;
            inputManager.OnButtonYEvent -= ButtonYEventHandler;
        }

        private void ButtonYEventHandler(bool obj)
        {
            GetObject(0);
        }

        private void ButtonXEventHandler(bool obj)
        {
            GetObject(1);
        }

        private void ButtonBEventHandler(bool obj)
        {
            GetObject(2);
        }

        private void ButtonAEventHandler(bool obj)
        {
            GetObject(3);
        }
        private void GetObject(int index)
        {
            if (canSpawn)
            {
                var objTemp = ObjectPoolingWithLinq.Instance.GetObjectFromPool(element, spawnPosition.position, true);
                objTemp.GetComponent<ElementIDScript>().ElemID = elemIDs[index];
                canSpawn = false;
                spawnTimer = tempTimer;
                openAnim.Play("Open");
            }

        }
        #endregion


    }
}
