using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    None,
    SunflowerSeed
}
public class Collectable : MonoBehaviour
{
    public CollectableType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Destroy(gameObject);
    }
}
