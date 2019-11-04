//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PetrusGames.HelperLibrary
{
    public class DesActivateObjectsAfterTime : MonoBehaviour
    {
        [Header("Set Time To Disactivate Object")]
        [SerializeField] private float desactivationTime;
        private float resetTime;


        private void Awake()
        {
            resetTime = desactivationTime;
        }
        private void Start()
        {
            ResetDesactivationTime();
        }
        private void Update()
        {
            desactivationTime -= Time.deltaTime;
            if(desactivationTime < 0)
            {
                gameObject.SetActive(false);
            }
        }

        public void ResetDesactivationTime()
        {
            desactivationTime = resetTime;
        }
    }
}