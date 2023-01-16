using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject sunflowerPrefab;
    private TileManager tileManager;
    private GameObject flower;

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

        Vector3 position = tileManager.GetTilePosition(new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0));
        if (!tileManager.IsInteractable(Vector3Int.FloorToInt(position))) return;
        if (!FarmManager.Instance.IsOccupied(Vector3Int.FloorToInt(position)))
        {
            FarmManager.Instance.FillTile(Vector3Int.FloorToInt(position));
            Instantiate(sunflowerPrefab, position, Quaternion.identity);
        }

        else if (FarmManager.Instance.IsOccupied(Vector3Int.FloorToInt(position),3))
        {
            FarmManager.Instance.ClearTile(Vector3Int.FloorToInt(position));
            Inventory.Instance.Add(CollectableType.SunflowerSeed);
            Destroy(flower);
            flower = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Sunflower")) return;

        flower = collision.gameObject;
    }

}

