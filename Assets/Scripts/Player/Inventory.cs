using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int SunflowerSeedAmount => sunflowerSeedAmount;
    public int TulipSeedAmount => tulipSeedAmount;
    public int RoseSeedAmount => roseSeedAmount;

    [SerializeField] private InventoryUI inventoryUI;

    private int sunflowerSeedAmount = 0;
    private int tulipSeedAmount = 0;
    private int roseSeedAmount = 0;
    public void Add(CollectableType type) 
    {
        if (type == CollectableType.SunflowerSeed) sunflowerSeedAmount++;
        else if (type == CollectableType.TulipSeed) tulipSeedAmount++;
        else if (type == CollectableType.RoseSeed) roseSeedAmount++;

        inventoryUI.Refresh();
    }
}
