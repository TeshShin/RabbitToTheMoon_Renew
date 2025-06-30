using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �̱���
    private static GameManager inst;
    public static GameManager Inst
    {
        get
        {
            return inst;
        }
    }
    private bool isGameover = false;
    // ������ UI
    [SerializeField] private GameObject[] Items;
    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("���� ���� �Ŵ����� �� �̻� �����մϴ�!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // ���� ���� ��, �����̽� ������ ���� �����
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
