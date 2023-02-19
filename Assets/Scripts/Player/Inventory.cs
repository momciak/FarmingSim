using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public int SunflowerAmount => sunflowerAmount;
    public int SeedAmount => seedAmount;
    public int CoinAmount => coinAmount;

    private InventoryUI inventoryUI => InventoryUI.Instance;

    private int sunflowerAmount = 0;
    private int seedAmount = 3;
    private int coinAmount = 0;

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
    public void Add(CollectableType type) 
    {
        if (type == CollectableType.Sunflower) sunflowerAmount++;
        if (type == CollectableType.Coin) coinAmount++;
        if (type == CollectableType.Seed) seedAmount++;

        inventoryUI.Refresh();
    }

    public void Add(CollectableType type, int amount)
    {
        if (type == CollectableType.Sunflower) sunflowerAmount += amount;
        if (type == CollectableType.Coin) coinAmount += amount;
        if (type == CollectableType.Seed) seedAmount += amount;

        inventoryUI.Refresh();
    }

    public void Remove(CollectableType type)
    {
        if (type == CollectableType.Sunflower) sunflowerAmount--;
        if (type == CollectableType.Coin) coinAmount--;
        if (type == CollectableType.Seed) seedAmount--;

        inventoryUI.Refresh();
    }

    public void RemoveAll(CollectableType type)
    {
        if (type == CollectableType.Sunflower) sunflowerAmount = 0;
        if (type == CollectableType.Coin) coinAmount = 0;
        if (type == CollectableType.Seed) seedAmount = 0;

        inventoryUI.Refresh();
    }
    public int GetCollectableAmount(CollectableType type)
    {
        if (type == CollectableType.Coin) return coinAmount;
        else if (type == CollectableType.Sunflower) return sunflowerAmount;
        else if (type == CollectableType.Seed) return seedAmount;
        return 0;
    }
}
