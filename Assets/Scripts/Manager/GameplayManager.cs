using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }

    public Vector2Int PriceRange { get { return priceRange; } set { priceRange = value; } }

    public int FlowerGrowthTime { get { return flowerGrowthTime; } set { flowerGrowthTime = value; } }

    [SerializeField] private int flowerGrowthTime;
    [SerializeField] private Vector2Int priceRange;
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
}
