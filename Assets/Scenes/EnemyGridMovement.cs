using UnityEngine;

public class EnemyGridMovement : MonoBehaviour
{
    private GridTransform gridTransform;

    private GridManager gridManager;
    private DangerZone dangerZone;

    [SerializeField] private float moveDelay = 1f;

    private float moveTimer;

    private void Start()
    {
        gridTransform = GetComponent<GridTransform>();
       
        gridManager = GetComponentInParent<GridManager>();
  
        dangerZone = FindFirstObjectByType<DangerZone>();

        moveTimer = moveDelay;
    }

    private void Update()
    {
        moveTimer -= Time.deltaTime;

        // Move down one grid space whenever the timer finishes.
        if (moveTimer <= 0f)
        {
            gridTransform.Move(new Vector2Int(0, -1));

            // Check if the enemy reached the bottom row.
            CheckDangerZone();

            moveTimer = moveDelay;
        }
    }

    private void CheckDangerZone()
    {
        // Find where this enemy currently is on the grid.
        Vector2Int enemyPosition =
            gridManager.GetPositionOfObject(gameObject);

        
        if (enemyPosition.y == 0)
        {
            
            dangerZone.EnemyEntered();

            
            gridManager.DestoryObjectAtGridPos(enemyPosition);
        }
    }
}