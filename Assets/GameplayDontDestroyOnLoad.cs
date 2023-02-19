using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayDontDestroyOnLoad : MonoBehaviour
{
    static List<GameplayDontDestroyOnLoad> Instances = new List<GameplayDontDestroyOnLoad>();

    public static void ClearAll()
    {
        foreach (var item in Instances)
        {
            Destroy(item.gameObject);
        }
        Instances.Clear();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instances.Add(this);
    }
}
