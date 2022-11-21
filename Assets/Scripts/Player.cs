using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numSunflowerSeed = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Sunflower")) return;

        numSunflowerSeed++;
    }
}