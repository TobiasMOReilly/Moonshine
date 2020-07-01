using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    [SerializeField] private GameEvent finishLineEvent;

    private void OnTriggerEnter(Collider other)
    {


        if(other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerState>().GetPlayer().isWinner = true;
            finishLineEvent.Raise();
        }
    }

}
