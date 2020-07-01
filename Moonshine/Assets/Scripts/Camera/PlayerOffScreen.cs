using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffScreen : MonoBehaviour {

    //List of players
    [SerializeField] private List<Player> players;
    [SerializeField] private Camera cam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check if players are off screen ( world to screen.x > screeen width.x)
        if (players.Count > 1)
        {
            foreach (Player p in players)
            {
                if (cam.WorldToScreenPoint(p.GetCurrentPosition()).x > Screen.width)
                {
                    //set the players reset position to leaders current posistion
                    print("OFF SCREEN: " + p.name);
                    //p.SetResetPosition(LeadingPlayerPosition());
                    p.SetResetTransform(LeadingPlayerTransform());
                    p.RaisePlayerOffScreenEvent();
                }
            }
        }
	}
    //Find leading player transform
    private Transform LeadingPlayerTransform()
    {
        Player closestPlayer = players[0];
        //Convert both players positions to sceen space
        //Find the player closest to left side
        //Set leading player variable
        foreach (Player p in players)
        {
            //if(cam.WorldToScreenPoint(p.GetCurrentPosition()).x < cam.WorldToScreenPoint(closestPlayer.GetCurrentPosition()).x)
            if (cam.WorldToScreenPoint(p.GetCurrentTransform().position).x < cam.WorldToScreenPoint(closestPlayer.GetCurrentTransform().position).x)
            {
                closestPlayer = p;
            }
        }
        //print("Leading Player : " + closestPlayer.name);
        return closestPlayer.GetCurrentTransform();
    }
    //find and remove dead players from player list
    public void RemoveDeadPlayers()
    {
        print("Removing players");
        for (int i = players.Count - 1; i >= 0; i--)
        {
            if (players[i].IsDead())
            {
                players.Remove(players[i]);
            }
        }
        print(players.Count);
    }
}
