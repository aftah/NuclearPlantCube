using AftahGames.NuclearSimulator;
using PetrusGames.NuclearPlant.Managers.Data;
using PetrusGames.NuclearPlant.Objects.Elements;
using System;
using UnityEngine;

namespace ThibautPetit
{
    public class ConveyorBelt : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private PlayerAbility playerAbility;
        #endregion

        #region PRIVATE FIELDS
        private float converyorBeltSpeed;
        private bool movingLeft;

        #endregion

        #region PUBLIC PROPERTIES
        public bool MovingLeft { get => movingLeft;}
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<bool> onChangeDirection;
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            converyorBeltSpeed = DataManager.Instance.ConveryorBeltSpeed;
        }

        private void OnEnable()
        {
            playerAbility.OnConveyorBelt += ConveyorBeltHandler;
        }

        private void OnDisable()
        {
            playerAbility.OnConveyorBelt -= ConveyorBeltHandler;
        }

        private void ConveyorBeltHandler(bool obj)
        {
            StopAndRestart();
        }

        private void StopAndRestart()
        {
            movingLeft = !movingLeft;
            onChangeDirection?.Invoke(movingLeft);
        }

       // aftah put ontrigger for sound
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {

                SoundManager.Instance.PlaySound("ElementOnBelt");
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                if(other.GetComponent<ElementIDScript>().IsGrabbed == false)
                {
                    MoveElement(other.gameObject);
                }              
            }                
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Element"))
            {
                other.GetComponent<Rigidbody>().isKinematic = false;
                //aftah put the sound
                SoundManager.Instance.StopSound("ConveyorBeltLeft");
                SoundManager.Instance.StopSound("ConveyorBeltRight");
            }
        }

        private void MoveElement(GameObject elem)
        {
            elem.GetComponent<Rigidbody>().isKinematic = true;
            elem.transform.Translate((MovingLeft ? Vector3.left : Vector3.right) * converyorBeltSpeed * Time.deltaTime);

            //aftah put the sound
            if (MovingLeft)
            {
                SoundManager.Instance.PlaySound("ConveyorBeltLeft");

            }
            else
            {
                SoundManager.Instance.PlaySound("ConveyorBeltRight");

            }

        }
        #endregion
    }
}
