//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using UnityEngine;

namespace PetrusGames.NuclearPlant.Objects.Fire
{
    public class FireObjectScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("Set Default Behavior for Fire")]
        [SerializeField] private bool IsLifeTimed;
        [SerializeField] private float time;
        [SerializeField] private GameObject parentObject,fireManager;
        #endregion

        #region PRIVATE FIELDS
        private float TempTime;
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
            TempTime = time;
            SoundManager.Instance.PlaySound("Fire");
        }

        // Update is called once per frame
        void Update()
    {
            DisableAfterTime();
    }
/// <summary>
/// if IsLifeTimed is true then the fireobject will disactivate after the time is depleated
/// </summary>
     private void DisableAfterTime()
     {
            if (IsLifeTimed == true)
            {
                TempTime -= Time.deltaTime;
                if (TempTime < 0)
                {
                    TempTime = time;
                    parentObject.SetActive(false);
                }
               
            }
     }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                this.gameObject.SetActive(false);
                other.gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.gameObject.tag == "Exctinctor")
            {
                this.gameObject.SetActive(false);
                //collision.gameObject.SetActive(false);

            }
        }

        private void OnEnable()
        {
            FireManagerScript.Instance.TotalFireDamageAdd = 1;
        }
        private void OnDisable()
        {
            FireManagerScript.Instance.TotalFireDamageRemove = 1;
        }
        #endregion


    }
}
