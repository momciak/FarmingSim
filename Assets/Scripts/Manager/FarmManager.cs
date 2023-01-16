using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance { get; private set; }

    [SerializeField] private Vector2Int offset;
    
    private int[,] field;

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        field = new int[3,3];
    }
    public bool IsOccupied(Vector3Int position)
    {
        if (field[position.x + offset.x, offset.y - position.y] == 0) return false;
        return true;
    }

    public bool IsOccupied(Vector3Int position, int index)
    {
        if (field[position.x + offset.x, offset.y - position.y] != index) return false;
        return true;
    }

    public void ClearTile(Vector3Int position)
    {
        if (!IsOccupied(position,3)) return;

        field[position.x + offset.x, offset.y - position.y] = 0;
    }
    
    public void FillTile(Vector3Int position)
    {
        if (IsOccupied(position)) return;

        field[position.x + offset.x, offset.y - position.y] = 1;
    }

    public void IncreaseTileValue(Vector3Int position)
    {
        if (!IsOccupied(position)) return;

        field[position.x + offset.x, offset.y - position.y]++;
    }
}