using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayLives : MonoBehaviour {

    [SerializeField] private Player player;

    private TextMeshProUGUI textPro;

    // Use this for initialization
    void Start () {
        textPro = GetComponentInChildren<TextMeshProUGUI>();
        UpdateLivesText();
    }
	
	public void UpdateLivesText()
    {
        textPro.text = "Lives: " + player.GetCurrentLives();
        //print("Lives: " + player.GetCurrentLives());
    }
}
