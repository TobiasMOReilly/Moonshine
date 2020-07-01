using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    //[SerializeField] private GameEvent outOfBoundsEvent;
    [SerializeField] private List<Player> players;

    private Transform resetTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            GameObject currentPlayer = other.gameObject;
            Player player = currentPlayer.GetComponent<PlayerState>().GetPlayer();

            //Set the players onTrack bool to false
            player.onTrack = false;

            //if there is a player on the track set reset transform to that player
            if(isPlayerOnTrack())
            {
                print("PLAYER ON THE TRACK");
                resetTransform = PlayerOnTrack().GetCurrentTransform();
                player.SetResetTransform(resetTransform);
            }
            else //There are no players on the track, set reset transform to current checkpoint
            {
                print("NO PLAYERS ON TRACK");
                resetTransform = player.GetCurrentCheckPoint().transform;
                player.SetResetTransform(resetTransform);

           }

            //Raise event for player
            player.RaiseOutOfBoundsEvent();
            player.onTrack = true;
        }
    }

    //Find the player still on the track
    private Player PlayerOnTrack()
    {
        Player player = players[0];

        for(int i= players.Count - 1; i >= 0; i --)
        {
            if(players[i].onTrack)
            {
                player = players[i];
                break;
            }
        }

        return player;
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
