//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This code is written by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PetrusGames
{
    public class MenuManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("Menu Items")]
        [SerializeField] private List<GameObject> menuItems;
        [Header("Selected Menu Item")]
        [SerializeField] private Text SelMenuItem;
        [Header("List Of Menu Items Title")]
        [SerializeField] private List<string> Strings;
        #endregion

        #region PRIVATE FIELDS
        private int menuItemAtMAx = 0;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

          // Start is called before the first frame update
    void Start()
        {
            SetScales(1, 0.75f, 0.5f, 0.5f);
            SelMenuItem.text = Strings[0];
        }

    // Update is called once per frame
    void Update()
        {
            TestMenuInputs();

        }
   

    private void SetMenuScale(int munuItemAtHundred)
        {
            switch (munuItemAtHundred)
            {
                case  0  :
                    SetScales(1, 0.750f, 0.5f, 0.5f);
                    SelMenuItem.text = Strings[0];
                    break;
                case 1:
                    SetScales(0.75f, 1, 0.750f, 0.5f);
                    SelMenuItem.text = Strings[1];
                    break;
                case 2:
                    SetScales(0.5f, 0.750f, 1, 0.750f);
                    SelMenuItem.text = Strings[2];
                    break;
                case 3:
                    SetScales(0.5f, 0.5f, 0.750f, 1);
                    SelMenuItem.text = Strings[3];
                    break;


                default:
                    SetScales(1, 0.750f, 0.5f, 0.5f);
                    SelMenuItem.text = Strings[0];
                    break;
            }
        }
        #endregion
    private void SetScales(float a,float b, float c,float d)
        {
            menuItems[0].transform.localScale = new Vector3(a, a, a);
            menuItems[1].transform.localScale = new Vector3(b, b, b);
            menuItems[2].transform.localScale = new Vector3(c, c, c);
            menuItems[3].transform.localScale = new Vector3(d, d, d);


        }
    private void TestMenuInputs()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (menuItemAtMAx < 3)
                {
                    menuItemAtMAx++;
                }
                else
                {
                    menuItemAtMAx = 0;
                }
                SetMenuScale(menuItemAtMAx);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (menuItemAtMAx > 0)
                {
                    menuItemAtMAx--;
                }
                else
                {
                    menuItemAtMAx = 3;
                }
                SetMenuScale(menuItemAtMAx);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(menuItemAtMAx + 1);
            }
        }
    }

 
}
