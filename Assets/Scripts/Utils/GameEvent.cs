using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Utils/Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    public void raise()
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].onEventRaised();
        }
    }

    public void registerListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void unregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
