using Assets.DTO;
using CodeMonkey.Utils;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {   
        scoreText = transform.Find("scoreText").GetComponent<Text>();

        if(SceneManager.GetActiveScene().name.ToString() == "Lvl1") {
            transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl1); };
        }

        if (SceneManager.GetActiveScene().name.ToString() == "Lvl2")
        {
            transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl2); };
        }

        if (SceneManager.GetActiveScene().name.ToString() == "Lvl3")
        {
            transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl3); };
        }

        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Menu); };       
    }

    public void callCheckHighScore()
    {

        StartCoroutine(CheckHighScore());

    }

    IEnumerator CheckHighScore()
    {

        WWWForm form = new WWWForm();
        form.AddField("idUser", DBManager.id);
        form.AddField("score", scoreText.text);
        form.AddField("map", SceneManager.GetActiveScene().name.ToString());
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/checkHighScore.php", form);
        
        while (!www.isDone)
        {
            Debug.Log("Waiting");
        }

        return www;
    }

    public void callMapsCheckHighScore()
    {
        StartCoroutine(MapsCheckHighScore());
    }

    IEnumerator MapsCheckHighScore()
    {

        WWWForm form = new WWWForm();
        form.AddField("idUser", DBManager.id);
        form.AddField("map", SceneManager.GetActiveScene().name.ToString());
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/getHighScoresUser.php", form);

        yield return www;


        if (www.text != "" && SceneManager.GetActiveScene().name.ToString() == "Lvl1")
        {
            DTO_UpdateScore updateScore = JsonConvert.DeserializeObject<DTO_UpdateScore>(www.text);

            DBManager.firstMap = updateScore.mapScore;
        }else
        if (www.text != "" && SceneManager.GetActiveScene().name.ToString() == "Lvl2")
        {
            DTO_UpdateScore updateScore = JsonConvert.DeserializeObject<DTO_UpdateScore>(www.text);

            DBManager.secondMap = updateScore.mapScore;
        }
        else
        if (www.text != "" && SceneManager.GetActiveScene().name.ToString() == "Lvl3")
        {
            DTO_UpdateScore updateScore = JsonConvert.DeserializeObject<DTO_UpdateScore>(www.text);

            DBManager.thirdMap = updateScore.mapScore;
        }

    }


    public void callAddCoins()
    {
        StartCoroutine(AddCoins());
    }

    IEnumerator AddCoins()
    {
        WWWForm form = new WWWForm();
        form.AddField("idUser", DBManager.id);
        form.AddField("coins", scoreText.text);
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/addCoins.php", form);

        while (!www.isDone)
        {
            Debug.Log("Waiting");
        }

        if (www.text != "")
        {            
            DBManager.coins = int.Parse(www.text);
        }

        return www;
    }


    private void Start()
    {        
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {       
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        Show();
        callCheckHighScore();
        callMapsCheckHighScore();
        callAddCoins();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
