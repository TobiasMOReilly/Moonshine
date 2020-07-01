using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour {

    [SerializeField] private List<Player> players;
    [SerializeField] private GameObject menu;

    private bool gameOver;

	// Use this for initialization
	void Start () {
        gameOver = false;
        //print("GameOver Start");
	}
	
    public void RunMenu()
    {
        if (!gameOver)
        {
            CheckAllDead();
        }
        print("Attempting to run");
        if (gameOver)
        {
            print("GameOver");
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //Check if all players are dead
    private void CheckAllDead()
    {
        foreach(Player p in players)
        {
            if(!p.IsDead())
            {
                gameOver = false;
                break;
            }
            else
            {
                gameOver = true;
            }
        }
    }
    //SetGameOver
    public void SetGameOver()
    {
        gameOver = true;
    }

    //Reset the scene
    public void ResetScene()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Go to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
