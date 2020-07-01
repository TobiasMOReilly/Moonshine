using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //two player button
    public void TwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayer");
    }
    //four player button
    public void FourPlayer()
    {
        SceneManager.LoadScene("FourPlayer");
    }
    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
