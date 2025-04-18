using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Ensure the collider has the "Player" tag before invoking the event
        if (other.CompareTag("Player"))
        {
            if (EventManager.Instance != null)
            {
                EventManager.Instance.onDoorOpened?.Invoke();
                Debug.Log("Player entered the trigger zone. Event triggered!");
            }
            else
            {
                Debug.LogWarning("EventManager instance is null! Ensure it is assigned.");
            }
        }
    }
}
