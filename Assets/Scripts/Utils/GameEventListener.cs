using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent;

    [SerializeField]
    private UnityEvent response;

    private void OnEnable()
    {
        gameEvent.registerListener(this);
    }

    private void OnDisable()
    {
        gameEvent.unregisterListener(this);
    }

    public void onEventRaised()
    {
        response.Invoke();
    }
}
