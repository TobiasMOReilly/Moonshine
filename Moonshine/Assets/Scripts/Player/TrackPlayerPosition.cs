using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerPosition : MonoBehaviour {

    [SerializeField] private List<WheelCollider> wheels;

    private bool isGrounded;
    private Vector3 lastPostion;

	// Update is called once per frame
	void Update () {
        TrackPosition();
    }

    //Track current raceTrack position
    private void TrackPosition()
    {
        //check all wheels are grounded
        foreach(WheelCollider wheel in wheels)
        {
            if(wheel.isGrounded)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                break;
            }
        }
        //if all wheels grounded track position
        if(isGrounded)
        {
            lastPostion = transform.position;
            //print("Position: " + lastPostion);
        }
    }
}
