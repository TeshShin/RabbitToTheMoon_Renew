using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId; // 0 : body, 1 : Head, 2 : Left, 3 : Right, 4 : Fuel
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] itemSprites; // ID → 스프라이트
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ID에 따라 스프라이트 설정
        if (itemId >= 0 && itemId < itemSprites.Length)
        {
            spriteRenderer.sprite = itemSprites[itemId];
        }
    }
    void Update()
    {
        if (PlatformPoolManager.Inst.IsItemCollected(itemId))
        {
            TrySwitchToUncollected();
        }
    }
    /// <summary>
    /// 이미 생성된 아이템이 획득된 경우, 다른 획득되지 않은 아이템으로 변경한다.
    /// </summary>
    private void TrySwitchToUncollected()
    {
        List<int> uncollected = PlatformPoolManager.Inst.GetUncollectedItemIds();

        if (uncollected.Count == 0)
        {
            Destroy(gameObject);
            return;
        }

        int newId = uncollected[Random.Range(0, uncollected.Count)];
        itemId = newId;
        spriteRenderer.sprite = itemSprites[itemId];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemCollector"))
        {
            PlatformPoolManager.Inst.MarkItemAsCollected(itemId);
            GameManager.Inst.ItemSetActive(itemId);
            Destroy(gameObject); // 아이템 제거
        }
    }
}
