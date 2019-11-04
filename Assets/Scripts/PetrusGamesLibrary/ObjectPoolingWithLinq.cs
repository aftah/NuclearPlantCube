//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace PetrusGames.HelperLibrary
{

    public class ObjectPoolingWithLinq : MonoBehaviour
    {
        public static ObjectPoolingWithLinq Instance = new ObjectPoolingWithLinq();
        #region SERIALIZED FIELDS
        [Header("*   GameObject To Pool")]
        [SerializeField] private List<GameObject> poolingObjects, gameObjects;
        [Header("*   Number Of Startup Objects for each type of object")]
        [SerializeField] private int numberOfStartObjectsInPool;
        [Header("Set this as a singleton")]
        [SerializeField] private bool isSingleton;
        #endregion
        #region PRIVATE FIELDS
     
        #endregion
        #region PUBLIC PROPERTIES

        #endregion
        #region PRIVATE FUNCTIONS
        private void Start()
        {
            if (!isSingleton)
            {
                Destroy(Instance);
            }
            else
            {
                if(Instance != null)
                {
                    Destroy(this);
                }
                else
                {
                    Instance = this;
                }
            }
            for(var i = 0; i < numberOfStartObjectsInPool; i++)
            {
                foreach(var obj in poolingObjects)
                {
                    var o = Instantiate(obj);
                    gameObjects.Add(o);
                    o.SetActive(false);
                    o.transform.position = Vector3.zero;
                }
            }
        }
        private GameObject GetSingleObjectFromPool(GameObject ObjectToTakeFromPool)
        {
            var objlist = gameObjects.Where(O => O.tag == ObjectToTakeFromPool.tag);
            var obj = objlist.Where(o => o.activeSelf == false).First();
            return obj;
        }
        #endregion
        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Get an Object That is availeble in this GameObject pool
        /// if there is no object availeble a new object will be added to the pool
        /// 
        /// Do not forget to add a tag to your objectprefab
        /// 
        /// if setactive is true the object is activated from start at StartPosition
        /// </summary>
        /// <param name="Object"></param>
        /// <param name="SetActive"></param>
        /// <param name="StartPosition"></param>
        /// <returns></returns>
        public GameObject GetObjectFromPool(GameObject Object,Vector3 StartPosition,bool SetActive)
        {
            try
            {
                GameObject obj = GetSingleObjectFromPool(Object);
                obj.transform.position = StartPosition;
                if(SetActive) {
                    obj.SetActive(true);
                    //obj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                }
                if (obj == null)
                {
                    var newObj = Instantiate(Object);
                    gameObjects.Add(newObj);
                    obj.transform.position = StartPosition;
                    if (SetActive) {
                        newObj.SetActive(true);
                        //newObj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                    }
                    else { newObj.SetActive(false); }
                    return newObj;
                }
                else
                {
                    return obj;
                }
               
            }
            catch
            {
                var newObj = Instantiate(Object);
                gameObjects.Add(newObj);
                newObj.transform.position = StartPosition;
                if (SetActive)
                {
                    newObj.SetActive(true);
                    //newObj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                }
                else { newObj.SetActive(false); }
                return newObj;
            }
             
        }
        /// <summary>
        /// Get an Object That is availeble in this GameObject pool
        /// if there is no object availeble a new object will be added to the pool
        /// 
        /// if setactive is true the object is activated from start at StartPosition and StartRotation
        /// </summary>
        /// <param name="Object"></param>
        /// <param name="SetActive"></param>
        /// <param name="StartPosition"></param>
        /// <param name="StartRotation"></param>
        /// <returns></returns>
        public GameObject GetObjectFromPool(GameObject Object, Vector3 StartPosition, Quaternion StartRotation, bool SetActive)
        {
            try
            {
                GameObject obj = GetSingleObjectFromPool(Object);
                obj.transform.position = StartPosition;
                obj.transform.rotation = StartRotation;
                if (SetActive) {
                    obj.SetActive(true);
                    //obj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                }
                if (obj == null)
                {
                    var newObj = Instantiate(Object);
                    gameObjects.Add(newObj);
                    newObj.transform.position = StartPosition;
                    newObj.transform.rotation = StartRotation;
                    if (SetActive)
                    {
                        newObj.SetActive(true);
                        //newObj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                    }
                    else { newObj.SetActive(false); }
                    return newObj;
                }
                else
                {
                    return obj;
                }

            }
            catch
            {
                var newObj = Instantiate(Object);
                gameObjects.Add(newObj);
                newObj.transform.position = StartPosition;
                newObj.transform.rotation = StartRotation;
                if (SetActive) {
                    newObj.SetActive(true);
                    //newObj.GetComponent<DesActivateObjectsAfterTime>().ResetDesactivationTime();
                }
                else { newObj.SetActive(false); }
                return newObj;
            }

        }
        #endregion

    }

}