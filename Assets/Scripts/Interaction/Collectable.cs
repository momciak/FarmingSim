using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Sunflower,
    Seed,
    Coin
}
public class Collectable : MonoBehaviour
{
    public CollectableType Type;
    public bool IsGrown { get; private set; } = false;
  
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
        }
        if (Time.time - spawnTime >= GameplayManager.Instance.FlowerGrowthTime *2 && spriteIndex == 1)
        {
            spriteIndex++;
            render.sprite = sprites[spriteIndex];

            IsGrown = true;
        }
    }
}
