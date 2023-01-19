using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConverter : MonoBehaviour
{
    [SerializeField] private CollectableType itemToConvert;
    [SerializeField] private CollectableType resultItem;
    private bool hasPlayer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasPlayer)
        {
            ConvertItem();
        }
    }

    public void ConvertItem()
    {
        if (Inventory.Instance.GetCollectableAmount(itemToConvert) == 0) return;

        Inventory.Instance.Add(resultItem, Prices.Instance.Price * Inventory.Instance.GetCollectableAmount(itemToConvert));
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
