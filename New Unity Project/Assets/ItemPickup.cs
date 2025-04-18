using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Added: Variable to store the item name
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Added: Store item in inventory
            EventManager.Instance.inventory.Add(itemName);

            // Trigger the item collected event
            EventManager.Instance.onItemCollected?.Invoke();

            // Destroy the item after collection
            Destroy(gameObject);
        }
    }
}
