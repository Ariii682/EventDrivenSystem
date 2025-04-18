using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public UnityEvent onItemCollected;
    public UnityEvent onDoorOpened;
    public List<string> inventory = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Debug.Log("EventManager Initialized!"); // ✅ Check if EventManager is active
    }

    public void CollectItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log("Item Collected: " + itemName); // ✅ Check if item is collected
        onItemCollected?.Invoke();
    }
}