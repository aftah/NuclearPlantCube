using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary.LeaderBoard;
using PetrusGames.HelperLibrary.Json;


namespace PetrusGames.HelperLibrary.TestScripts
{
    public class testAddScoreScript : MonoBehaviour
    {
        [Header("Add the addscore object from scene")]
        [SerializeField] private GameObject addScoreUtility;
        [Header("player name and score")]
        [SerializeField] private string playerName;
        [SerializeField] private int score;
        private void Awake()
        {
            JsonItem item = new JsonItem();
            item.Name = playerName;
            item.Score = score;
            addScoreUtility.GetComponent<AddScoreToLeadreBoard>().AddNewScoreToLeaderBoardJson(item);
        }
    }
}

