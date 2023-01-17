using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance { get; private set; }

    [SerializeField] private Vector2Int offset;
    
    private Collectable[,] field;

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
        field = new Collectable [3,3];
    }
    public bool IsOccupied(Vector3Int position)
    {
        if (field[position.x + offset.x, offset.y - position.y] == null) return false;
        return true;
    }

    public bool IsOccupied(Vector3Int position, bool isGrown)
    {
        if (field[position.x + offset.x, offset.y - position.y].IsGrown != isGrown) return false;
        return true;
    }

    public void ClearTile(Vector3Int position)
    {
        if (!IsOccupied(position,true)) return;

        Collectable collectable = field[position.x + offset.x, offset.y - position.y];

        Destroy(collectable.gameObject);

        field[position.x + offset.x, offset.y - position.y] = null;
    }
    
    public void FillTile(Vector3Int position, Collectable collectable)
    {
        if (IsOccupied(position)) return;

        field[position.x + offset.x, offset.y - position.y] = collectable;
    }
}