using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private GridTransform gridTransform;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    private void Start()
    {
        // Get the existing GridTransform so we can use movement here.

        gridTransform = GetComponent<GridTransform>();
    }

    private void Update()
    {
        Vector2Int input = new Vector2Int(0, 0);

        // Move one grid space to the left.

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            input.x = -1;
        }

        // Move one grid space to the right.

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            input.x = 1;
        }

        // Only moves when A / D pressed.

        if (input != Vector2Int.zero)
        {
            gridTransform.Move(input);
        }

        // Shoot one bullet when Space is pressed.
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        // Instantiates are bullet object.

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
