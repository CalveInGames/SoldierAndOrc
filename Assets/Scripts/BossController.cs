using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // Point where projectiles are spawned
    public float projectileForce = 10f; // Force applied to the projectile
    public float fireRate = 2f; // Rate at which projectiles are fired (in seconds)
    public int damageAmount = 10; // Amount of damage inflicted on the player per hit

    public int maxHealth = 100; // Maximum health of the boss
    private int currentHealth; // Current health of the boss

    public Slider healthBar; // Reference to the health bar UI

    private Transform player; // Reference to the player's transform
    private float nextFireTime; // Time to fire the next projectile

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        healthBar.gameObject.SetActive(false); // Hide the health bar initially

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to fire a projectile
        if (Time.time >= nextFireTime)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - firePoint.position).normalized;

            // Spawn a projectile
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            
            // Apply force to the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * projectileForce;
            }

            // Set the next fire time
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void TakeDamage(int damage) // Changed to public access modifier
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die(); // Boss dies if health reaches zero
        }

        // Show the health bar if it's not already visible
        if (!healthBar.gameObject.activeSelf)
        {
            healthBar.gameObject.SetActive(true);
        }
    }

    void Die()
    {
        // Implement death behavior (e.g., play death animation, disable boss GameObject)
        Debug.Log("Boss defeated!");
        gameObject.SetActive(false); // Disable the boss GameObject
        healthBar.gameObject.SetActive(false); // Hide the health bar
    }
}