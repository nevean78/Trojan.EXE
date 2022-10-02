using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterAndLogin : MonoBehaviour
{
  
    public void GoToRegister()
    {

        SceneManager.LoadScene(1);

    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
