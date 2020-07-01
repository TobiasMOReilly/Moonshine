using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RaceStartCount : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private GameEvent raceStart;

    private int currentCount;

	// Use this for initialization
	void Start () {
        currentCount = 3;
        StartCoroutine(StartCount());
    }

    //Count down From 3
    IEnumerator StartCount()
    {
        while (currentCount >= 1)
        {
            counter.text = "" + currentCount;
            yield return new WaitForSeconds(1);
            currentCount--;
        }
        counter.text = "!!MOONSHINE!!";
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        raceStart.Raise();
    }
}
