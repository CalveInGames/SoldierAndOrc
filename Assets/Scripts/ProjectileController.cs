using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed = 5f; // Speed of the projectile
    public int damageAmount = 10; // Amount of damage inflicted on the player

    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move towards the player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * projectileSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount);
            }

            // Destroy the projectile on impact with the player
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Boss")) // Destroy projectile if it hits something else
        {
            Destroy(gameObject);
        }
    }
}