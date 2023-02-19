using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remainingTimeText;
    private float startTime;
    private void Update()
    {
        if (Time.time - startTime <= GameplayManager.Instance.GameTime)
        {
            remainingTimeText.text = "Time Left: " + ((int)(GameplayManager.Instance.GameTime - (Time.time - startTime))).ToString();

        }
        else 
        {
            remainingTimeText.text = "Time Left: 0";
            //GameOverController.Instance.ShowGameOverWindow();
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                GameplayDontDestroyOnLoad.ClearAll();
                SceneManager.LoadScene(0);
            }
        }

    }
    private void Start()
    {
        startTime = Time.time;
    }
}
