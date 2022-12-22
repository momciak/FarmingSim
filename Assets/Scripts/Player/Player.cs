using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sunflower")) inventory.Add(CollectableType.SunflowerSeed);
        else if (collision.CompareTag("Rose")) inventory.Add(CollectableType.RoseSeed);
        else if (collision.CompareTag("Tulip")) inventory.Add(CollectableType.TulipSeed);
    }
}