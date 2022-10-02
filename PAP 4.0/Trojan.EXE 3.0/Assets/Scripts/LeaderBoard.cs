using Assets.DTO;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text leaderBoardUserDisplay;
    public Text leaderBoardScoreDisplay;
    public Text leaderBoardMapDisplay;

    public Text playerDisplay;
    public Text coinsDisplay;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(leaderBoard());
        playerDisplay.text = DBManager.username.ToString();
        coinsDisplay.text = DBManager.coins.ToString();          
    }


    IEnumerator leaderBoard()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/top10.php", form);

        while (!www.isDone)
        {
            Debug.Log("Waiting");
        }

        yield return www;
          
        if (www.text != "")
        {
            List<DTO_UsersScores> usersScores = JsonConvert.DeserializeObject<List<DTO_UsersScores>>(www.text);

            foreach (var item in usersScores)
            {
                leaderBoardUserDisplay.text += item.login + "\n";
                leaderBoardScoreDisplay.text += item.score + "\n";
                leaderBoardMapDisplay.text += item.map + "\n";
            }
        }     
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
