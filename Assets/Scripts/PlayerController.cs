using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int coinCount = 0;
    private int health = 100;
    private int keyCount = 0;

    public Text coinsText; // For standard UI Text
    public Text keysText; // For standard UI Text
    public Text healthText; // For standard UI Text
    public GameObject gameOverScreen; // Reference to the game over screen GameObject

    private bool isGameOver = false; // Flag to track game over state

    void Start()
    {
        UpdateUI();
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
        if (isGameOver) return; // Exit early if game over

        health -= amount;
        if (health < 0) health = 0;
        UpdateUI();

        if (health <= 0)
        {
            // Game Over logic here (show Game Over screen, restart level, etc.)
            Debug.Log("Game Over");

            // Activate game over screen
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }
            else
            {
                Debug.LogError("gameOverScreen reference is not set in the Inspector!");
            }

            isGameOver = true; // Set game over flag
            
            // Disable Rigidbody
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.isKinematic = true; // Disable physics interactions
            }
            else
            {
                Debug.LogError("Rigidbody component not found on player GameObject!");
            }

            DisablePlayerInput(); // Disable player input
        }
    }

    private void DisablePlayerInput()
    {
        // Implement logic to disable player input here
        // Replace 'CharacterMovement' with the actual script responsible for character movement

        // Example: Disable CharacterMovement script
        CharacterMovement characterMovement = GetComponent<CharacterMovement>();
        if (characterMovement != null)
        {
            characterMovement.enabled = false;
        }
        else
        {
            Debug.LogError("CharacterMovement component not found on player GameObject!");
        }

        // Add more disabling logic as needed for your specific game
    }

    private void UpdateUI()
    {
        coinsText.text = "Coins: " + coinCount;
        keysText.text = "Keys: " + keyCount;
        healthText.text = "Health: " + health;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
}