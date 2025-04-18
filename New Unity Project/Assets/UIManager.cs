using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public Text inventoryText;

    private void Start()
    {
        Debug.Log("UIManager Started!"); // ✅ Check if script is running
        EventManager.Instance.onItemCollected.AddListener(UpdateScore);
        EventManager.Instance.onItemCollected.AddListener(UpdateUI);
    }

    public void UpdateScore()
    {
        score++;
        Debug.Log("Score Updated: " + score); // ✅ Check if score updates
        scoreText.text = "Score: " + score;
    }

    void UpdateUI()
    {
        Debug.Log("Updating Inventory UI...");
        inventoryText.text = "Inventory: " + string.Join(", ", EventManager.Instance.inventory);
        Debug.Log("Updated Inventory: " + inventoryText.text);
    }
}
