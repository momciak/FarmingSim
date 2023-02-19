using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Collectable sunflowerPrefab;
    private void Start()
    {
    }
    private void Update()
    {
        Interact();
    }
    void Interact()
    {
        if (!Input.GetKeyDown(KeyCode.F)) return;

        var tileManager = TileManager.Instance;
        Vector3 position = tileManager.GetTilePosition(new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0));
        if (!tileManager.IsInteractable(Vector3Int.FloorToInt(position))) return;
        if (!FarmManager.Instance.IsOccupied(Vector3Int.FloorToInt(position)))
        {
            if (Inventory.Instance.SeedAmount > 0)
            {
                Collectable collectable = Instantiate(sunflowerPrefab, position, Quaternion.identity);
                FarmManager.Instance.FillTile(Vector3Int.FloorToInt(position), collectable);
                Inventory.Instance.Remove(CollectableType.Seed);
            }
        }
        else if (FarmManager.Instance.IsOccupied(Vector3Int.FloorToInt(position), true))
        {
            FarmManager.Instance.ClearTile(Vector3Int.FloorToInt(position));
            Inventory.Instance.Add(CollectableType.Sunflower);
        }
    }

}

