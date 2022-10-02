using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text InfoTxt;

    private static PopUp instance;

    public static int map;

    public static PopUp GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
        transform.Find("buyBtn").GetComponent<Button_UI>().ClickFunc = () => { BuyMap(); };
        transform.Find("cancelBtn").GetComponent<Button_UI>().ClickFunc = () => { Hide(); };        
    }
    // Start is called before the first frame update
    public void Start()
    {
        Hide();
    }

    private void Update()
    {

        if (map == 2)
        {
            InfoTxt.text = DBManager.secondMapPrice.ToString() + "$";
        }

        if (map == 3)
        {
            InfoTxt.text = DBManager.thirdMapPrice.ToString() + "$";
        }
    }

    private void BuyMap()
    {
        StartCoroutine(buyMap());
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    IEnumerator buyMap()
    {
        WWWForm form = new WWWForm();
        form.AddField("idUser", DBManager.id);
        form.AddField("idMap", map);
        form.AddField("coins", DBManager.coins);
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/buyMap.php", form);

        while (!www.isDone)
        {
            Debug.Log("Waiting");
        }

        Debug.Log(www.text);

        if (www.text == "1")
        {
            if (map == 2)
            {
                DBManager.coins = DBManager.coins - 500;
                DBManager.secondMapOwned = true;
            }
            else
            if (map == 3)
            {
                DBManager.coins = DBManager.coins - 1000;
                DBManager.thirdMapOwned = true;
            }
        }

        return www;
    }
}
