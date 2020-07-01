using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    [SerializeField] AudioClip engine;
    [SerializeField] AudioClip drink;
    [SerializeField] AudioSource mainSource;
    [SerializeField] AudioSource secondSource;

    private Rigidbody rigidbody;
    private float pitch;
    private bool playing = false;

    // Use this for initialization
    void Start () {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
            print("Got RB");
    }
	
	// Update is called once per frame
	void Update () {
        pitch = rigidbody.velocity.magnitude;
        mainSource.pitch = pitch;

        if (!playing)
        {
            playing = true;
            mainSource.clip = engine;
            mainSource.Play();
        }

    }

    //Play drinking clip if item consumed (EVENT)
    public void PlayDrinkClip()
    {
        secondSource.PlayOneShot(drink, 1);
    }
}
