using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject PauseMenuUI;
    public GameObject CraftMenuUI;

    // Update is called once per frame

    void Start()
    {
        PauseMenuUI.SetActive(false);
        CraftMenuUI.SetActive(false);
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }
        }
      if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                CraftPause();
            }
            
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Pausing game");
    }

    void CraftPause()
    {
        CraftMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Pausing game");
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        CraftMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Resuming Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
