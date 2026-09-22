using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Color hitColor = Color.red;
    [SerializeField] private float flashTime = 0.15f;

    private int currentHealth;
    private Color normalColor;

    private void Start()
    {
        // Start this object at full health.
        currentHealth = maxHealth;

        // Remember its original color so we can return to it.
        normalColor = objectRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Object flashes red on collision/
        StartCoroutine(Flash());

        // Destoroy.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator Flash()
    {
        objectRenderer.material.color = hitColor;

        yield return new WaitForSeconds(flashTime);

        objectRenderer.material.color = normalColor;
    }

    private void Die()
    {
        // Only enemies should be counted as score.

        if (CompareTag("Enemy"))
        {
            ScoreManager scoreManager =
                FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
        }

        Destroy(gameObject);
    }
    public int GetHealth()
    {
        return currentHealth;
    }
}