using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject menu;

    private bool gameIsPaused;

	// Use this for initialization
	void Start () {
        gameIsPaused = false;	
	}
	
    public void RunPause()
    {
        print("RAn Pause");
        //menu.SetActive(false);

        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        gameIsPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    private void Pause()
    {
        gameIsPaused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    //Reset the scene
    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
    //Go to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
