using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    [SerializeField] private GameObject menu;
    [SerializeField] private List<Player> players;
    [SerializeField] private GameObject winningTeam;
    [SerializeField] private GameObject jugsCollected;
    [SerializeField] private GameObject jugsThrown;
    [SerializeField] private GameObject jugsConsumed;
    [SerializeField] private GameObject time;

    private Player winner;

    public void RunMenu()
    {
        GetWinners();
        print("Winner: " + winner);
        Time.timeScale = 0;
        menu.SetActive(true);
        print(winner.timeToFinish);
        winningTeam.GetComponent<TextMeshProUGUI>().text = winner.name;
        jugsCollected.GetComponent<TextMeshProUGUI>().text = "Jugs Collected: " + winner.jugsCollected;
        jugsThrown.GetComponent<TextMeshProUGUI>().text = "Jugs Thrown: " + winner.jugsThrown;
        jugsConsumed.GetComponent<TextMeshProUGUI>().text = "Jugs Consumed: " + winner.jugsConsumed;
        time.GetComponent<TextMeshProUGUI>().text = "Time: " + winner.timeToFinish;
    }

    //Get the winning players
    private void GetWinners()
    {
        foreach(Player p in players)
        {
            if(p.isWinner)
            {
                winner = p;
                break;
            }
        }
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
