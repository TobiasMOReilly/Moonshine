using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetManager : MonoBehaviour {
    [SerializeField] private List<Player> players;
    //[SerializeField] private List<GameObject> checkPoints;

    private Transform resetTransform;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(allPlayersOnTrack());

        //if both players off track reset pos == current checkpoint
        //if leading player off track reset pos == current checkpoint
            //else reset postion == leading player position
        //if player off screen reset pos == leading player pos
	}
    
    //Set reset transform for player
    public void SetResetTransform()
    {
        print("SET RESET TRANSFORM");
        foreach(Player p in players)
        {
            //if the current player in not on the track
            if(!p.onTrack)
            {   //if there is another player on the track, set current players reset transform to that player 
                if(isPlayerOnTrack())
                {
                    print("PLAYER ON THE TRACK");
                    resetTransform = PlayerOnTrack().GetCurrentTransform();
                    p.SetResetTransform(resetTransform);
                }
                else //There are no players on the track, set reset transform to current checkpoint
                {
                    print("NO PLAYERS ON TRACK");
                    resetTransform = p.GetCurrentCheckPoint().transform;
                    p.SetResetTransform(resetTransform);

                }
            }
            p.RaiseResetTransformEvent();
        }
    }
    //Check if a player is on the track
    private bool isPlayerOnTrack()
    {
        bool temp = true;

        foreach (Player p in players)
        {
            if (p.onTrack)
            {
                temp = true;
                break;
            }
            else
            {
                temp = false;
            }
        }
        return temp;
    }
    //Check if all Players Are off the track
    private bool allPlayersOnTrack()
    {
        bool temp = true;

        foreach (Player p in players)
        {
            if (!p.onTrack)
            {
                temp = false;
                break;
            }
            else
            {
                temp = true;
            }
        }
        return temp;
    }
    //Find the player still on the track
    private Player PlayerOnTrack()
    {
        Player player = players[0];

        for (int i = players.Count - 1; i >= 0; i--)
        {
            if (players[i].onTrack)
            {
                player = players[i];
                break;
            }
        }

        return player;
    }
}
