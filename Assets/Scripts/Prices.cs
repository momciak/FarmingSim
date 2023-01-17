using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prices : MonoBehaviour
{
    private int price;

    private void Start()
    {
        InvokeRepeating(nameof(PricesRandomizer), 3, 10);
    }
    public void PricesRandomizer()
    {
       price = Random.Range(GameplayManager.Instance.PriceRange.x, GameplayManager.Instance.PriceRange.y);
    }
}
