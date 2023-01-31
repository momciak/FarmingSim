using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static GameOverController Instance { get; private set; }
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI score;
   
    private void OnEnable()
    {
        Time.timeScale = 1;
    }

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
    public void  ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);

        if (GameplayManager.Instance.CoinsToWin <= Inventory.Instance.CoinAmount)
        {
            title.text = "Congrats!";
            score.text = "You managed to collect " + Inventory.Instance.CoinAmount + " coins!";
        }
        else
        {
            title.text = "You lose!";
            score.text = "You managed to collect " + Inventory.Instance.CoinAmount + " coins!";
        }

        Time.timeScale = 0;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);   
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
