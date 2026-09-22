using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletLifeTime = 3f;

    private void Start()
    {
        // Destroy the bullet for existing for too long.
        Destroy(gameObject, bulletLifeTime);
    }

    private void Update()
    {
        // transform + forward = bullet moving forward.
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Get universal health script.
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(1);
            }

            // Bullet disappears after hitting an enemy.
            Destroy(gameObject);
        }
    }
}