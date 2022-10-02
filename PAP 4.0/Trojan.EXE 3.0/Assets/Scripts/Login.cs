using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
  
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

   
    public void callLogin(){

        StartCoroutine(LoginPlayer());

    }

    IEnumerator LoginPlayer()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.coins = int.Parse(www.text.Split('\t')[1]);
            DBManager.id = int.Parse(www.text.Split('\t')[2]);
            DBManager.firstMap = int.Parse(www.text.Split('\t')[3]);
            DBManager.secondMap = int.Parse(www.text.Split('\t')[4]);
            DBManager.thirdMap = int.Parse(www.text.Split('\t')[5]);
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("Erro no login. Erro #" + www.text);
        }

    }

    public void VerifyInputs()
    {

        submitButton.interactable = (nameField.text.Length >= 5 && nameField.text.Length <= 10 && passwordField.text.Length >= 5);

    }  
}