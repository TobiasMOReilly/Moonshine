using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLives : MonoBehaviour {

    [SerializeField] private Player player;
    
    public void RemoveLife()
    {
        player.DecrementLives();
        
        if(player.IsDead())
        {
            print("Player Dead");
            player.RaisePlayerDeadEvent();
            this.gameObject.SetActive(false);
        }
    }
}
