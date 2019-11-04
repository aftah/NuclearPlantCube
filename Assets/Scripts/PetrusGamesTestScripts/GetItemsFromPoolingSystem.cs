//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames.HelperLibrary.TestScripts
{
    public class GetItemsFromPoolingSystem : MonoBehaviour
    {

        [Header("Set Objects To spawn from pool")]
        [SerializeField] private GameObject oBject;
        [Header("Set time between spawns")]
        [SerializeField] private float Trigger;
        [Header("Set Start Position")]  
        [SerializeField] private Vector3 objectStartPosition = Vector3.zero;
        [Header("Set Start Rotation")]
        [SerializeField] private Quaternion StartRotation = Quaternion.Euler(Vector3.zero);
        private float timer;
        // Update is called once per frame
        private void Start()
        {
            timer = 0;
        }
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > Trigger)
            {
                ObjectPoolingWithLinq.Instance.GetObjectFromPool(oBject, objectStartPosition, StartRotation, true);
                timer = 0;
            }
        }
    }
}