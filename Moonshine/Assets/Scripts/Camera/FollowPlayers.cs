using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayers : MonoBehaviour {

    [SerializeField] private List<Player> players;
    [SerializeField] private Camera cam;

    private Vector3 centerPosition;
    private Vector3 leadingPlayerPosition;
    private Vector3 pointToTrack;
    
	// Use this for initialization
	void Start () {
        CalculateCenterVector();
    }
	
	// Update is called once per frame
	void Update () {

        //LeadingPlayerPosition();
        if (players.Count > 0)
        {
            SetCameraTrackPosition(LeadingPlayerPosition());
        }
    }

    //Calculate the center vector between the two players
    private void CalculateCenterVector()
    {
        Vector3 sumOfvectors = new Vector3(0,0,0);
        //Get the current  position for each player from the
        foreach(Player p in players)
        {
            //sumOfvectors += p.GetCurrentPosition();
            if (p.GetCurrentTransform() != null)
            {
                sumOfvectors += p.GetCurrentTransform().position;
            }
        }

        centerPosition = sumOfvectors / players.Count;
    }
    //Set the transform of the camera
    private void SetCameraTrackPosition(Vector3 position)
    {
        //transform.position = centerPosition + offset;
        transform.position = position;
    }

    //Find leading player position
    private Vector3 LeadingPlayerPosition()
    {
        Player closestPlayer = players[0];
        //Convert both players positions to sceen space
        //Find the player closest to left side
        //Set leading player variable

        if (players.Count > 1)
        {
            foreach (Player p in players)
            {
                //if(cam.WorldToScreenPoint(p.GetCurrentPosition()).x < cam.WorldToScreenPoint(closestPlayer.GetCurrentPosition()).x)
                if (cam.WorldToScreenPoint(p.GetCurrentTransform().position).x < cam.WorldToScreenPoint(closestPlayer.GetCurrentTransform().position).x)
                {
                    closestPlayer = p;
                }
            }
        }
        //print("Leading Player : " + closestPlayer.name);
        return closestPlayer.GetCurrentPosition();
    }

    //Calculate the point centered between leading player and center point between players
    private void CalculatePointToTrack()
    {
        Vector3 trackPoint;

        trackPoint = (leadingPlayerPosition + centerPosition) /2;

        pointToTrack = trackPoint;
    }

    //find and remove dead players from player list
    public void RemoveDeadPlayers()
    {
        print("Removing players");
        for(int i=players.Count-1; i >= 0; i--)
        {
            if(players[i].IsDead())
            {
                players.Remove(players[i]);
            }
        }
        print(players.Count);
    }
}
