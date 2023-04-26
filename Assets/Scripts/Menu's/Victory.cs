using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void YesButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void NoButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
