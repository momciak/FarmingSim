using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prices : MonoBehaviour
{
    public static Prices Instance { get; private set; }
    public int SeedPrice => seedPrice;
    public int CoinPrice => coinPrice;
    private int seedPrice;
    private int coinPrice;

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
        InvokeRepeating(nameof(PricesRandomizer), 3, 10);
    }
   
    public void PricesRandomizer()
    {
       seedPrice = Random.Range(GameplayManager.Instance.SeedPriceRange.x, GameplayManager.Instance.SeedPriceRange.y);
       coinPrice = Random.Range(GameplayManager.Instance.CoinPriceRange.x, GameplayManager.Instance.CoinPriceRange.y);
    }


}
