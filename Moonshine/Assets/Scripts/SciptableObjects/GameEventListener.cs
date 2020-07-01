using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public GameEvent Event;
    public UnityEvent Response;
    public List<GameEvent> events;

    private void OnEnable()
    {
        if (Event != null)
        {
            Event.RegisterListener(this);
        }
        foreach(GameEvent e in events)
        {
            e.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        if (Event != null)
        {
            Event.UnregisterListener(this);
        }
        foreach (GameEvent e in events)
        {
            e.UnregisterListener(this);
        }
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
