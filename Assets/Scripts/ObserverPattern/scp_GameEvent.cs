using System.Collections.Generic;
using UnityEngine;

//Adds a new option to the create menu allowing us to make new scriptable objects automatically
[CreateAssetMenu(fileName ="New Game Event", menuName = "Scriptable Objects/Game Event")]

public class scp_GameEvent : ScriptableObject
{
    //Will store all the listeners in this variable
    private List<scp_GameEventListener> listeners = new List<scp_GameEventListener>();


    //The Raise() method will tell all the subscribers to Invoke() their response
    public void Raise()
    {
        //It goes through all the listeners, and notifies
        //them that the event has been raised
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    //Registers a listener to the list
    public void RegisterListeners(scp_GameEventListener listener)
    {
        listeners.Add(listener);

    }

    //Unregisters a listener from the list
    public void UnregisterListener(scp_GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
