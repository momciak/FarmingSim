using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI sunflowerAmountText;
    [SerializeField]
    private TextMeshProUGUI seedAmountText;
    [SerializeField]
    private TextMeshProUGUI coinAmountText;
    
    public void Refresh()
    {
        sunflowerAmountText.text = $"x {Inventory.Instance.SunflowerAmount}";
        coinAmountText.text = $"x {Inventory.Instance.CoinAmount}/{GameplayManager.Instance.CoinsToWin}";
        seedAmountText.text = $"x {Inventory.Instance.SeedAmount}";
    }
    private void Start()
    {
        Refresh();
    }
}

