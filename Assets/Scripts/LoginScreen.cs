using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreen : MonoBehaviour
{
    public void PlayButtonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

}
