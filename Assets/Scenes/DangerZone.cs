using System.Collections;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    [SerializeField] private Renderer zoneRenderer;

    [SerializeField] private Color normalColor = Color.red;
    [SerializeField] private Color flashColor = Color.yellow;

    [SerializeField] private float flashTime = 0.2f;


    private void Start()
    {
        // Make the Danger Zone fit across the first row.
        FitDangerZone();

        // Start the Danger Zone as red.
        zoneRenderer.material.color = normalColor;
    }


    private void FitDangerZone()
    {
        // Get the total width of the grid.
        float gridWidth = gridManager.GetWidth() * gridManager.GetGridScale();

        float gridScale = gridManager.GetGridScale();

        // Stretch the cube across one full row.
        transform.localScale = new Vector3(gridWidth,0.1f, gridScale);

        // Move the cube so it lines up with the bottom row.
        transform.position = gridManager.transform.position + 
            new Vector3((gridWidth - gridScale) / 2f, 0.05f , 0f );
    }


    public void EnemyEntered()
    {
        // Find the Player that was spawned into the grid.
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            
            Health playerHealth =
                player.GetComponent<Health>();

            if (playerHealth != null)
            {
                // Enemy escaped, so Player loses one health.
                playerHealth.TakeDamage(1);
            }
        }

        // Flash the Danger Zone when an enemy gets through.
        StartCoroutine(FlashYellow());
    }


    private IEnumerator FlashYellow()
    {
        // Change Danger Zone to yellow.
        zoneRenderer.material.color = flashColor;

        yield return new WaitForSeconds(flashTime);

        // Return Danger Zone to red.
        zoneRenderer.material.color = normalColor;
    }
}