using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPoolManager : MonoBehaviour
{
    // 싱글톤
    private static PlatformPoolManager inst;
    public static PlatformPoolManager Inst
    {
        get
        {
            return inst;
        }
    }

    [SerializeField] private GameObject platformPrefab;
	private int poolSize = 30; // 미리 만들어둘 플랫폼 개수

    private float levelWidth = 8f;
    private float minY = 1f;
    // 플레이어가 밟을 수 있는 현재 일반 발판과 다음 일반 발판의 최대 차이는 약 3.5362 이다.
    private float maxY = 3.5f;

	private List<GameObject> platformPool;
	private float highestY = 0f;


    /// <summary>
    /// 발판에 생성될 아이템 관리
    /// </summary>
    [SerializeField] private GameObject itemPrefab; // 단 하나의 공통 아이템 프리팹
    private HashSet<int> collectedItemIds = new HashSet<int>(); // 획득된 아이템
    private List<int> allItemIds = new List<int>() { 0, 1, 2, 3, 4 };

    private void Awake()
	{
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("PlatformPoolManager가 둘 이상 존재합니다!");
            Destroy(this);
        }
	}
    private void Start()
    {
        // 오브젝트 풀 생성
        platformPool = new List<GameObject>();
        Vector3 spawnPosition = new Vector3(0f, -4.5f, 0f);

        for (int i = 0; i < poolSize; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            // 타입 지정
            SetPlatformType(platform);
            TrySpawnItem(platform); // 아이템 생성 시도
            platformPool.Add(platform);

            if (spawnPosition.y > highestY)
                highestY = spawnPosition.y;
        }
    }
    public void Relocation(GameObject platform)
    {
        // 새 위치로 재배치
        highestY += Random.Range(minY, maxY);
        float newX = Random.Range(-levelWidth, levelWidth);
        platform.transform.position = new Vector3(newX, highestY, 0);
        // 재배치 시 발판의 종류 재결정
        SetPlatformType(platform);

        // 기존 아이템 제거
        foreach (Transform child in platform.transform)
        {
            if (child.CompareTag("Item"))
                Destroy(child.gameObject);
        }
        // 아이템 재생성 시도
        TrySpawnItem(platform);
    }
    /// <summary>
    /// 확률에 따른 발판의 종류 결정
    /// </summary>
    /// <param name="platform">발판</param>
    private void SetPlatformType(GameObject platform)
    {
        Platform p = platform.GetComponent<Platform>();
        if (p == null) return;

        float rand = Random.value;
        float moving = Random.value;
        if (rand < 0.9f) // 90%
        {
            if(moving < 0.6f) // 60%
            {
                p.SetType(Platform.PlatformType.Normal); // 노말 타일
            }
            else // 40%
            {
                p.SetType(Platform.PlatformType.Moving); // 움직이는 노말 타일
            }

        }
        else // 10%
        {
            if (moving < 0.6f)
            {
                p.SetType(Platform.PlatformType.SuperJump); // 슈퍼 점프 타일
            }
            else
            {
                p.SetType(Platform.PlatformType.MovingSuperJump); // 움직이는 슈퍼 점프 타일
            }
            
        }
            
    }

    /// <summary>
    /// 아이템을 수집 처리하고 UI에 표시합니다.
    /// </summary>
    /// <param name="itemId">수집한 아이템의 고유 ID (0~4)</param>
    public void MarkItemAsCollected(int itemId)
    {
        if (!collectedItemIds.Contains(itemId))
        {
            collectedItemIds.Add(itemId);
            SkyManager.Inst.OnItemCollected();
        }
    }

    public int GetCollectedItemsCount()
    {
        return collectedItemIds.Count;
    }

    /// <summary>
    /// 아직 획득하지 못한 아이템을 생성합니다.
    /// </summary>
    /// <param name="platform">아이템을 생성할 발판</param>
    private void TrySpawnItem(GameObject platform)
    {
        if (Random.value > 0.1f) return; // 10% 확률

        // 아직 획득되지 않은 아이템 중에서 랜덤 선택
        List<int> uncollected = new List<int>();
        foreach (int id in allItemIds) // 미획득 아이템만
        {
            if (!collectedItemIds.Contains(id))
                uncollected.Add(id);
        }

        if (uncollected.Count == 0) return;

        int randomIndex = Random.Range(0, uncollected.Count);
        int chosenId = uncollected[randomIndex];

        GameObject item = Instantiate(itemPrefab,
            platform.transform.position + Vector3.up * 0.223f,
            Quaternion.identity);
        item.GetComponent<Item>().itemId = chosenId;
        item.transform.SetParent(platform.transform);
    }
    /// <summary>
    /// 아이템이 획득됐는지 확인합니다.
    /// </summary>
    /// <param name="itemId">수집한 아이템의 고유 ID (0~4)</param>
    /// <returns>획득된 아이템인지</returns>
    public bool IsItemCollected(int itemId)
    {
        return collectedItemIds.Contains(itemId);
    }
    /// <summary>
    /// 획득되지 않은 아이템의 리스트를 얻습니다.
    /// </summary>
    /// <returns>획득되지 않은 아이템 리스트</returns>
    public List<int> GetUncollectedItemIds()
    {
        List<int> uncollected = new List<int>();
        foreach (int id in allItemIds)
        {
            if (!collectedItemIds.Contains(id))
                uncollected.Add(id);
        }
        return uncollected;
    }
}

