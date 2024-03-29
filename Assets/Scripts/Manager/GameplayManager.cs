using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }

    public Vector2Int SeedPriceRange { get { return seedPriceRange; } set { seedPriceRange = value; } }

    public Vector2Int CoinPriceRange { get { return coinPriceRange; } set { coinPriceRange = value; } }

    public int FlowerGrowthTime { get { return flowerGrowthTime; } set { flowerGrowthTime = value; } }

    public float GameTime { get { return gameTime; } set { gameTime = value; } }

    public int CoinsToWin { get { return coinsToWin; } set { coinsToWin = value; } }

    [SerializeField] private int flowerGrowthTime;
    [SerializeField] private Vector2Int seedPriceRange;
    [SerializeField] private Vector2Int coinPriceRange;
    [SerializeField] private float gameTime;
    [SerializeField] private int coinsToWin;
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
