using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;

    private void Awake()
    {
        if (Instance != null && Instance != this )
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }
    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile != null) return true;
        return false;
    }
}
