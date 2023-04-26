using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] UIObjects;

    AudioSource[] audios;

    public static bool isPaused; // False by default and static bool is a global variable 

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        audios = GetComponentsInChildren<AudioSource>(); // This gets all the audio source of the childrens in the heirarchy.        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        else
        {
            isPaused = false;
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

        for(int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        foreach (AudioSource a in audios)
        {
            a.Play();
        }

        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].SetActive(true);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        isPaused = false;
    }
}
