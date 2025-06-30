using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    private static GameManager inst;
    public static GameManager Inst
    {
        get
        {
            return inst;
        }
    }
    private bool isGameover = false;
    // 아이템 UI
    [SerializeField] private GameObject[] Items;
    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("씬에 게임 매니저가 둘 이상 존재합니다!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // 게임 오버 시, 스페이스 누르면 게임 재시작
        if(isGameover && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }

    public void ItemSetActive(int id)
    {
        Items[id].SetActive(true);
        if(PlatformPoolManager.Inst.GetCollectedItemsCount() == 5)
        {
            SceneManager.LoadScene("8. EndingScene");
        }
    }
}
