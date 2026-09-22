using System;
using UnityEngine;

// This class is just an example of how to using the grid from other scripts
public class GameManagerGridExample : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GameObject playerObject;

    [SerializeField] Vector2Int playerStartPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridManager.InstantiateObjectOnGrid(playerStartPosition, playerObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
