using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerState>().GetPlayer().SetCurrentCheckPoint(this.gameObject);

            print(other.gameObject.GetComponent<PlayerState>().GetPlayer().GetCurrentCheckPoint());
        }
    }
}
