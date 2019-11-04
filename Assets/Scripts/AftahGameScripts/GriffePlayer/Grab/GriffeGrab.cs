//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.HelperLibrary;
using PetrusGames.NuclearPlant.Objects.Elements;
using UnityEngine;


namespace AftahGames.NuclearSimulator
{
    public class GriffeGrab : MonoBehaviour
    {
        private GameObject grabObject;
       

        [SerializeField] private Animator anim;
        [SerializeField] private Input_Manager inputManager;

      
        private void OnEnable()
        {
            inputManager.OnGrabEvent += Input_OnGrabEvent;
            inputManager.OnReleaseGrabEvent += Input_OnReleaseGrabEvent;

        }


        private void Input_OnGrabEvent(float obj, bool isGrab)
        {

            anim.SetFloat(AnimatorParamHelper.PARAM_GRAB_VELOCITY, obj);

            SoundManager.Instance.StopSound("OpenGrab");
            SoundManager.Instance.PlaySound("CloseGrab");

            if (grabObject != null)
            {


                grabObject.GetComponent<Rigidbody>().isKinematic = true;
                grabObject.GetComponent<ElementIDScript>().IsGrabbed = true;
                grabObject.GetComponent<BoxCollider>().isTrigger = true;
                grabObject.GetComponent<Rigidbody>().useGravity = false;
                grabObject.transform.parent = this.transform;


            }
        }

        private void Input_OnReleaseGrabEvent(float obj, bool isRelease)
        {

            anim.SetFloat(AnimatorParamHelper.PARAM_GRAB_VELOCITY, obj);

            SoundManager.Instance.StopSound("CloseGrab");
            SoundManager.Instance.PlaySound("OpenGrab");

            if (isRelease == true)
            {

                if (grabObject != null)
                {
                    if (grabObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT))
                    {

                        grabObject.GetComponent<Rigidbody>().isKinematic = false;
                        grabObject.GetComponent<ElementIDScript>().IsGrabbed = false;
                        grabObject.GetComponent<BoxCollider>().isTrigger = false;
                        grabObject.GetComponent<Rigidbody>().useGravity = true;

                        grabObject.transform.parent = null;

                    }
                }
                grabObject = null;

            }
        }
        private void OnDisable()
        {
            inputManager.OnGrabEvent -= Input_OnGrabEvent;
            inputManager.OnReleaseGrabEvent -= Input_OnReleaseGrabEvent;

        }


        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT))
            {

                grabObject = other.gameObject;

            }

        }


        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT))
            {

                grabObject = null;

            }
        }




    }
}
