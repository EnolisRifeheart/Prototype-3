using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GridManager gridManager;

    public void SetGridManager(GridManager newManager)
    {
        // Remember which grid this enemy belongs to.
        gridManager = GetComponentInParent<GridManager>();
    }

    public void Die()
    {
        // Find which grid enemy position is at.
        Vector2Int enemyPosition =
            gridManager.GetPositionOfObject(gameObject);

        // use the grid to tag and destroy enemy. 
        gridManager.DestoryObjectAtGridPos(enemyPosition);
    }
}