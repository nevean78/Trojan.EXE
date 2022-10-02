using Assets.DTO;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highScoreText;

    private void Awake()
    {       
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highScoreText = transform.Find("highScoreText").GetComponent<Text>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.ToString() == "Lvl1")
        {
            highScoreText.text = "High Score: " + DBManager.firstMap.ToString();
        }

        if (SceneManager.GetActiveScene().name.ToString() == "Lvl2")
        {
            highScoreText.text = "High Score: " + DBManager.secondMap.ToString();
        }

        if (SceneManager.GetActiveScene().name.ToString() == "Lvl3")
        {
            highScoreText.text = "High Score: " + DBManager.thirdMap.ToString();
        }       
    }

    private void Update()
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
    }

}
