using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemConverter : MonoBehaviour
{
    [SerializeField] private CollectableType itemToConvert;
    [SerializeField] private CollectableType resultItem;
    [SerializeField] private TextMeshPro priceText;
    [SerializeField] private Image itemToConvertImage;
    [SerializeField] private Image resultItemImage;
    [SerializeField] private Sprite sunflowerSprite;
    [SerializeField] private Sprite coinSprite;
    [SerializeField] private Sprite seedSprite;
    private bool hasPlayer;

    private void OnEnable()
    {
        Prices.OnPriceChangeEvent += RefreshText;
    }

    private void OnDisable()
    {
        Prices.OnPriceChangeEvent -= RefreshText;
    }
    private void Start()
    {
        RefreshImages();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasPlayer)
        {
            ConvertItem();
        }
    }

    private void RefreshText()
    {
        if (resultItem == CollectableType.Coin) priceText.text = Prices.Instance.CoinPrice.ToString();
        else if (resultItem == CollectableType.Seed) priceText.text = Prices.Instance.SeedPrice.ToString();
    }

    private void RefreshImages()
    {
        if (itemToConvert == CollectableType.Coin) itemToConvertImage.sprite = coinSprite;
        else if (itemToConvert == CollectableType.Seed) itemToConvertImage.sprite = seedSprite;
        else if (itemToConvert == CollectableType.Sunflower) itemToConvertImage.sprite = sunflowerSprite;

        if (resultItem == CollectableType.Coin) resultItemImage.sprite = coinSprite;
        else if (resultItem == CollectableType.Seed) resultItemImage.sprite = seedSprite;
        else if (resultItem == CollectableType.Sunflower) resultItemImage.sprite = sunflowerSprite;
    }

    private void ConvertItem()
    {
        if (Inventory.Instance.GetCollectableAmount(itemToConvert) == 0) return;

        int price = 0;
        if (itemToConvert == CollectableType.Sunflower) price = Prices.Instance.CoinPrice;
        else if (itemToConvert == CollectableType.Coin) price = Prices.Instance.SeedPrice;

        Inventory.Instance.Add(resultItem, price * Inventory.Instance.GetCollectableAmount(itemToConvert));
        Inventory.Instance.RemoveAll(itemToConvert);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        hasPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        hasPlayer = false;
    }
}
