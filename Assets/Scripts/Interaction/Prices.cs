using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prices : MonoBehaviour
{
    public static Prices Instance { get; private set; }
    public int Price => price;
    private int price;

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
       price = Random.Range(GameplayManager.Instance.PriceRange.x, GameplayManager.Instance.PriceRange.y);
    }
}
