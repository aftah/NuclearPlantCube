using AftahGames.NuclearSimulator;
using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;

namespace ThibautPetit
{
    //Abonner GetPauseInput à l'input Manager
    public class CoolantMove : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private PlayerAbility playerAbility;
        #endregion

        #region PRIVATE FIELDS
        private float coolantSpeed;
        private bool isMoving = true;
        private bool movingLeft = true;
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
            coolantSpeed = DataManager.Instance.CoolantSpeed;
            SoundManager.Instance.PlaySound("FanOnMovement");

        }

        private void OnEnable()
        {
            playerAbility.OnCoolerEvent += CoolerEventHandler;
        }

        private void OnDisable()
        {
            playerAbility.OnCoolerEvent -= CoolerEventHandler;
        }

        private void CoolerEventHandler(bool obj)
        {
          
            Pause();

        }

        private void Pause()
        {
            isMoving = !isMoving;

            if (isMoving == false)
            {
                SoundManager.Instance.StopSound("FanOnMovement");
                SoundManager.Instance.PlaySound("PauseFan");
            }
            else
            {
                SoundManager.Instance.PlaySound("FanOnMovement");
                SoundManager.Instance.StopSound("PauseFan");
            }
        }

        void Update()
        {
            if (isMoving)
                Move();
        }


        private void Move()
        {
            
            gameObject.transform.Translate((movingLeft ? Vector3.left : Vector3.right) * coolantSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MaxRange"))
                movingLeft = !movingLeft;
        }

       
        #endregion
    }
}
