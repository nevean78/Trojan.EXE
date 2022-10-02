using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
  
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void callRegister(){

        StartCoroutine(Register());

    }

    IEnumerator Register()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://alpha.soaresbasto.pt/~goncalosilva/api/register.php", form);
        yield return www;
        if (www.text == "0")
        {

            Debug.Log("Utilizador criado com sucesso...");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
        else
        {
            Debug.Log("Falha ao criar utilizador... Erro #" + www.text);
        }
    }

    public void VerifyInputs()
    {

        submitButton.interactable = (nameField.text.Length >= 5 && passwordField.text.Length >= 5);

    }  
}
