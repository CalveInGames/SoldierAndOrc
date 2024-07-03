using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType { Coin, Health, Key }
    public CollectibleType type;
    public int healthAmount = 10; // Default health restoration amount

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                switch (type)
                {
                    case CollectibleType.Coin:
                        playerController.IncreaseCoins();
                        break;
                    case CollectibleType.Health:
                        playerController.RestoreHealth(healthAmount);
                        break;
                    case CollectibleType.Key:
                        playerController.AddKey();
                        break;
                }
            }
            Destroy(gameObject); // Remove the collectible from the scene
        }
    }
}