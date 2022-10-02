using Assets.DTO;
using CodeMonkey;
using CodeMonkey.Utils;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Text playerDisplay;
    public Text coinsDisplay;

    private void Awake()
    {
        
    }

    public void Update()
    {
        if (DBManager.firstMapOwned == true)
        {
            transform.Find("Level1").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl1); };
        }
        else
        {
            transform.Find("Level1").GetComponent<Button_UI>().ClickFunc = () => { PopUp.map = 1; PopUp.GetInstance().Show(); };
        }

        if (DBManager.secondMapOwned == true)
        {
            transform.Find("Level2").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl2); };
        }
        else
        {
            transform.Find("Level2").GetComponent<Button_UI>().ClickFunc = () => { PopUp.map = 2; PopUp.GetInstance().Show(); };
        }

        if (DBManager.thirdMapOwned == true)
        {
            transform.Find("Level3").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.Lvl3); };
        }
        else
        {
            transform.Find("Level3").GetComponent<Button_UI>().ClickFunc = () => { PopUp.map = 3; PopUp.GetInstance().Show(); };
        }

        playerDisplay.text = DBManager.username.ToString();
        coinsDisplay.text = DBManager.coins.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Start()
    {           
        StartCoroutine(checkMapsOwned());
    }

    IEnumerator checkMapsOwned()
    {
        WWWForm form = new WWWForm();
        form.AddField("idUser", DBManager.id);
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/getMapsOwned.php", form);

        while (!www.isDone)
        {
            Debug.Log("Waiting");
        }

        yield return www;

        if (www.text != "")
        {
            DTO_MapsOwnedAndPrice usersMapsOwnedAndPrice = JsonConvert.DeserializeObject<DTO_MapsOwnedAndPrice>(www.text);

            DBManager.firstMapOwned = usersMapsOwnedAndPrice.Lvl1;
            DBManager.secondMapOwned = usersMapsOwnedAndPrice.Lvl2;
            DBManager.thirdMapOwned = usersMapsOwnedAndPrice.Lvl3;

            DBManager.secondMapPrice = usersMapsOwnedAndPrice.Lvl2Price;
            DBManager.thirdMapPrice = usersMapsOwnedAndPrice.Lvl3Price;
        }
    }
}
