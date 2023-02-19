using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] 
    private TextMeshProUGUI sunflowerAmountText;
    [SerializeField]
    private TextMeshProUGUI seedAmountText;
    [SerializeField]
    private TextMeshProUGUI coinAmountText;

    private void Awake()
    {
        Instance = this;
    }

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

