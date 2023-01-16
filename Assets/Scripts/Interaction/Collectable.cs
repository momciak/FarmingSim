using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    None,
    SunflowerSeed,
    TulipSeed,
    RoseSeed,
}
public class Collectable : MonoBehaviour
{
    public CollectableType Type;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    private float spawnTime;
    private SpriteRenderer render;
    private int spriteIndex = 0;
    private void OnEnable()
    {
        spawnTime = Time.time;
    }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Grow();
    }

    private void Grow()
    {
        if (Time.time - spawnTime >= GameplayManager.Instance.FlowerGrowthTime && spriteIndex == 0)
        {
            spriteIndex++;
            render.sprite = sprites[spriteIndex];
            FarmManager.Instance.IncreaseTileValue(Vector3Int.FloorToInt(transform.position));
        }
        if (Time.time - spawnTime >= GameplayManager.Instance.FlowerGrowthTime *2 && spriteIndex == 1)
        {
            spriteIndex++;
            render.sprite = sprites[spriteIndex];
            FarmManager.Instance.IncreaseTileValue(Vector3Int.FloorToInt(transform.position));
        }
    }
}
