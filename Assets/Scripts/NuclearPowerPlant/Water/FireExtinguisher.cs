using AftahGames.NuclearSimulator;
using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThibautPetit
{
    public class FireExtinguisher : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private GameObject steam;
        [SerializeField] private float steamApparitionTime;
        [SerializeField] private List<GameObject> chargesDisplay = new List<GameObject>();
        [SerializeField] private Animator colliderAnim;
        [SerializeField] private Animator extinguisherAnim;
        [SerializeField] private PlayerAbility playerAbility;
        #endregion

        #region PRIVATE FIELDS
        private float extinguisherSpeed;
        private float chargesCoolDown;
        private int numberOfCharges;
        private bool movingLeft;
        #endregion

        #region PUBLIC PROPERTIES
        public int NumberOfCharges
        {
            get { return numberOfCharges; }
            set
            {
                numberOfCharges = value;
                UpdateDisplay();
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        private void OnEnable()
        {
            playerAbility.OnWaterGenerator += WaterGeneratorHandler;
        }

        private void OnDisable()
        {
            playerAbility.OnWaterGenerator -= WaterGeneratorHandler;
        }

        private void WaterGeneratorHandler(bool obj)
        {
            Shoot();
        }

        private void Start()
        {
            //aftah put sound
            SoundManager.Instance.PlaySound("ExtincteurMove");
            extinguisherSpeed = DataManager.Instance.ExtinguisherSpeed;
            chargesCoolDown = DataManager.Instance.ChargesCoolDown;
            numberOfCharges = chargesDisplay.Count;
            StartCoroutine("ChargesRegen");
        }

        #region PRIVATE FUNCTIONS
        private void Update()
        {
            Move();
        }


        private void Move()
        {
            gameObject.transform.Translate((movingLeft ? Vector3.left : Vector3.right) * extinguisherSpeed * Time.deltaTime);
            
        }

        private void Shoot()
        {
            if (NumberOfCharges > 0)
            {
                NumberOfCharges--;
                colliderAnim.SetTrigger("Exctinctor");
                StopCoroutine("ShowSteam");
                StartCoroutine("ShowSteam");
                extinguisherAnim.SetTrigger("Action");
                //Aftah put play sound
                SoundManager.Instance.PlaySound("Extincteur");
               

            }
        }

        private IEnumerator ShowSteam()
        {
            steam.SetActive(true);
            yield return new WaitForSeconds(steamApparitionTime);
            steam.SetActive(false);
        }

        private IEnumerator ChargesRegen()
        {
            yield return new WaitForSeconds(chargesCoolDown);
            if (numberOfCharges < chargesDisplay.Count )
                NumberOfCharges++;
            StartCoroutine("ChargesRegen");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MaxRange"))
                movingLeft = !movingLeft;
        }

        private void UpdateDisplay()
        {
            for (int i = 0; i < chargesDisplay.Count; i++)
            {
                if (numberOfCharges > i)
                    chargesDisplay[i].SetActive(true);
                else
                    chargesDisplay[i].SetActive(false);
            }
        }
        #endregion
    }
}
