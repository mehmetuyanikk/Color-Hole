using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void PlayAgainOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
