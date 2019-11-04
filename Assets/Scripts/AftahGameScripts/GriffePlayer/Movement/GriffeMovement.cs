//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;


namespace AftahGames.NuclearSimulator
{
    public class GriffeMovement : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private Transform minXminY, maxXmaxY;
        [SerializeField] private Input_Manager inputManager;
        #endregion

        #region PRIVATE FIELDS
        private float moveSpeed = 8f;

        private float minX, minY, maxX, maxY;
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
            moveSpeed = DataManager.Instance.ClawSpeed;
            minX = minXminY.position.x;
            minY = minXminY.position.y;
            maxX = maxXmaxY.position.x;
            maxY = maxXmaxY.position.y;
        }

        private void OnEnable()
        {
            inputManager.OnMoveEvent += Input_OnMove;
        }

        private void Update()
        {
            ClampPosition();
        }

        private void ClampPosition()
        {
            float XPos = transform.position.x;
            float YPos = transform.position.y;

            if (XPos < minX)
                XPos = minX;
            if (XPos > maxX)
                XPos = maxX;
            if (YPos < minY)
                YPos = minY;
            if (YPos > maxY)
                YPos = maxY;

            gameObject.transform.position = new Vector3(XPos, YPos, transform.position.z);
        }

        private void Input_OnMove(Vector3 obj)
        {
            transform.position += obj * moveSpeed * Time.deltaTime;
        }



        private void OnDisable()
        {
            inputManager.OnMoveEvent -= Input_OnMove;

        }



        #endregion

    }
}
