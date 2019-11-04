//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
using PetrusGames.NuclearPlant.Objects.Elements;




namespace PetrusGames.NuclearPlant.Objects.Elements
{
    public class ElementColorScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("A list of Materials to go with the ID of the Element")]
        [SerializeField] private List<Material> Materials;
        [Header("This Element's ID script")]
        [SerializeField] private ElementIDScript elementIDScript;
        [Header("This Element's Mesh Renderer")]
        [SerializeField] private MeshRenderer meshRenderer;
        #endregion

        #region PRIVATE FIELDS
        private Dictionary<elemID, Material> materials = new Dictionary<elemID, Material>();
        #endregion

        #region PUBLIC PROPERTIES

        #endregion

        #region PUBLIC FUNCTIONS
        public void SetRandomColor()
        {
            var mat = (elemID)Random.Range(0, 11);
            elementIDScript.ElemID = mat;
            SetMaterialToElement();
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS



        void Start()
        {
            int nr = 0;
            foreach (elemID id in (elemID[])Enum.GetValues(typeof(elemID)))
            {
                try
                {
                    materials.Add(id, Materials[nr]);
                }
                catch { Debug.Log("no material was found "); }
                nr++;
            }
            SetMaterialToElement();
        }


        // Update is called once per frame
        void Update()
        {

        }


        public void SetMaterialToElement()
        {
            if (materials.ContainsKey(elementIDScript.ElemID))
            {
                Material mat = materials[elementIDScript.ElemID];
                meshRenderer.material = mat;
            }
            else
            {
                Debug.Log("This dictionary does not have an entry with this key!!!");
            }
        }
        #endregion


    }
}
