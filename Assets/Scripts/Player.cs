using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numSunflowerSeed = 0;

    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Sunflower")) return;

        numSunflowerSeed++;
    }
    private void Awake()
    {
        inventory = new Inventory(21);
    }
}