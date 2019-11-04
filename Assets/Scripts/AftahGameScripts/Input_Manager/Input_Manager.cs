//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AftahGames.NuclearSimulator
{
    public class Input_Manager : MonoBehaviour
    {
        #region SERIALIZED FIELDS

        [SerializeField]
        [Range(0f, 1f)]
        private float grabVelocity = 1f;

        #endregion

        #region PUBLIC FIELDS

        #endregion

        #region PRIVATE FIELDS




        private bool isMoving = false;
        private Vector2 moveInput;


        #endregion

        #region PUBLIC PROPERTIES
        #endregion


        #region EVENTS


        public event Action<Vector3> OnMoveEvent;
        public event Action<float, bool> OnGrabEvent;
        public event Action<float, bool> OnReleaseGrabEvent;
        public event Action<bool> OnAbilityEvent;

        public event Action<bool> OnButtonAEvent;
        public event Action<bool> OnButtonBEvent;
        public event Action<bool> OnButtonXEvent;
        public event Action<bool> OnButtonYEvent;

        #endregion

        #region PUBLIC FUNCTIONS



        #endregion


        #region PRIVATE FUNCTIONS



        private void Update()
        {
            if (isMoving == true)
            {
                OnMoveEvent?.Invoke(new Vector3(moveInput.x, moveInput.y, 0));
            }


        }


        /// <summary>Get the vector2 from the input system</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnDirectional(InputAction.CallbackContext context)
        {
           
            moveInput = context.ReadValue<Vector2>();

            if (moveInput != Vector2.zero)
            {
                isMoving = true;

            }
            else
            {
                isMoving = false;
            }


        }


        //public void OnGrab(InputAction.CallbackContext context)
        //{


        //        float obj = context.ReadValue<float>();

        //        if (obj >= grabVelocity)
        //        {
        //            OnGrabEvent?.Invoke(obj, true);
        //        }
        //        else
        //        {
        //            OnReleaseGrabEvent?.Invoke(obj, true);
        //        }


        //}



        ///// <summary>Get the float Value of the Left Trigge (gamepad)r from the input control</summary>
        ///// <remarks>Generic event for all the player</remarks>
        public void OnGrab(InputAction.CallbackContext context)
        {


            if (context.performed)
                OnGrabEvent?.Invoke(1, true);
            else if (context.canceled)
                OnReleaseGrabEvent?.Invoke(0, true);

        }


        /// <summary>Get the button Right Trigger (gamepad) from the input control</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnAbility(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnAbilityEvent?.Invoke(true);


        }

        /// <summary>Get the button A (gamepad) from the input control</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnButtonA(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnButtonAEvent?.Invoke(true);

        }


        /// <summary>Get the button B (gamepad) from the input control</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnButtonB(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnButtonBEvent?.Invoke(true);

        }

        /// <summary>Get the button X (gamepad) from the input control</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnButtonX(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnButtonXEvent?.Invoke(true);

        }

        /// <summary>Get the button Y (gamepad) from the input control</summary>
        /// <remarks>Generic event for all the player</remarks>
        public void OnButtonY(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnButtonYEvent?.Invoke(true);

        }


        #endregion


        #region CLASS



        #endregion

    }
}
