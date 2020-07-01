using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
    [SerializeField] private List<Player> players;
    [SerializeField] private FloatReference MaxTime;
    [SerializeField] private GameEvent timeUpEvent;

    private TextMeshProUGUI textPro;

    private float currentMilliseconds;
    private float currentSeconds;
    private float currentMinutes;

    private string mins;
    private string secs;
    private string mills;

    private bool runClock;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        textPro = GetComponentInChildren<TextMeshProUGUI>();
        runClock = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (runClock)
        {
            StartClock();
        }
        if(currentMinutes >= MaxTime.Value-1)
        {
            textPro.color = Color.red;
        }
        if(currentMinutes == MaxTime.Value)
        {
            timeUpEvent.Raise();
        }
    }

    private void StartClock()
    {
        

        if (currentMilliseconds >= 59)
        {
            if (currentSeconds >= 59)
            {
                currentMinutes++;
                currentSeconds = 00;
            }
            else if (currentSeconds <= 59)
            {
                currentSeconds++;
            }

            currentMilliseconds = 0;
        }

       

        //Set up string to display
        if (currentMilliseconds < 10)
        {
            mills = "0" + Mathf.Round(currentMilliseconds);
        }
        else
        {
            mills = "" + Mathf.Round(currentMilliseconds);
        }
        if(currentSeconds < 10)
        {
            secs = "0" + currentSeconds;
        }
        else
        {
            secs ="" + currentSeconds;
        }
        if(currentMinutes < 10)
        {
            mins = "0" + currentMinutes;
        }
        else
        {
            mins ="" + currentMinutes;
        }

        textPro.text = mins + " : " + secs + " : " + mills;
        currentMilliseconds += Time.deltaTime * 100;
    }

    //Set winners time
    public void SetWinnersTime()
    {
        foreach (Player p in players)
        {
            if (p.isWinner)
            {
                p.timeToFinish = mins + " : " + secs + " : " + mills;
                break;
            }
        }
    }

    //Coroutine to flash clock colour
    IEnumerator ClockFlash()
    {
        while (true)
        {
            textPro.color = Color.red;
            yield return new WaitForSeconds(1);
            textPro.color = Color.white;
            print("CHANGE");
        }
    }

    //Set runClock bool
    public void SetRunClock()
    {
        runClock = !runClock;
    }
}
