using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI sunflowerAmountText;
    [SerializeField]
    private TextMeshProUGUI tulipAmountText;
    [SerializeField]
    private TextMeshProUGUI roseAmountText;

    [SerializeField]
    private Inventory inventory;
    
    public void Refresh()
    {
        sunflowerAmountText.text = $"x {inventory.SunflowerSeedAmount}";
    }
    private void Start()
    {
        Refresh();
    }
}

