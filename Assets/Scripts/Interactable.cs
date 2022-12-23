using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject sunflowerPrefab;
    private TileManager tileManager;

    private void Start()
    {
        tileManager = TileManager.Instance;
    }
    private void Update()
    {
        Interact();
    }
    void Interact()
    {
        if (!Input.GetKeyDown(KeyCode.F)) return;

        Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
        if (!tileManager.IsInteractable(position)) return;

        Instantiate(sunflowerPrefab, transform.position, Quaternion.identity);

    }
}
