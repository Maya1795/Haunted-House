using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;      // How fast the bullet flies
    public float lifetime = 5f;    // Auto-destroy after X seconds

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Launch the bullet forward
        rb.velocity = transform.forward * speed;
        // Clean up after itself
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if it hit a zombie
        ZombieHealth zombie = other.GetComponent<ZombieHealth>();
        if (zombie != null)
        {
            // Kill the zombie
            zombie.KillZombie();
            // Destroy the bullet immediately
            Destroy(gameObject);
        }
    }
}