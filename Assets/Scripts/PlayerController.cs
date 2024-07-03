using UnityEngine;
using UnityEngine.UI; // For standard UI Text
using TMPro; // For TextMeshPro

public class PlayerController : MonoBehaviour
{
    private int coinCount = 0;
    private int health = 100;
    private int keyCount = 0;

    public Text coinsText; // For standard UI Text
    public Text keysText; // For standard UI Text
    public Text healthText; // For standard UI Text

    // public TextMeshProUGUI coinsText; // Uncomment this if you are using TextMeshPro
    // public TextMeshProUGUI keysText; // Uncomment this if you are using TextMeshPro
    // public TextMeshProUGUI healthText; // Uncomment this if you are using TextMeshPro

    public GameObject gameOverPanel; // Reference to the Game Over Panel

    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false); // Ensure the Game Over Panel is hidden at the start
    }

    public void IncreaseCoins()
    {
        coinCount++;
        UpdateUI();
    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        if (health > 100) health = 100;
        UpdateUI();
    }

    public void AddKey()
    {
        keyCount++;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        UpdateUI();
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    private void UpdateUI()
    {
        coinsText.text = "Coins: " + coinCount;
        keysText.text = "Keys: " + keyCount;
        healthText.text = "Health: " + health;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Show the Game Over Panel
        Time.timeScale = 0; // Pause the game
    }

    // Other player control methods...
}