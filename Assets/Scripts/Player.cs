using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sunflower")) inventory.Add(CollectableType.SunflowerSeed);
        //
    }
    private void Awake()
    {
        inventory = new Inventory(21);
    }
}