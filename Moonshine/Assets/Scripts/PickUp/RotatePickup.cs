using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour {

    [SerializeField] private float RotateSpeed = 5f;
    [SerializeField] private float RotateX = 15f; //15
    [SerializeField] private float RotateY = 30f; //30
    [SerializeField] private float RotateZ = 45f; //45
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    //Rotate object
    private void Rotate()
    {
        transform.Rotate(new Vector3(RotateX, RotateY, RotateZ) * RotateSpeed * Time.deltaTime);
    }
}
