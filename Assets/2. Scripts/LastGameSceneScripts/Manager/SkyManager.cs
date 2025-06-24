using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    // �̱���
    private static SkyManager inst;
    public static SkyManager Inst
    {
        get
        {
            return inst;
        }
    }
    [SerializeField] private SkyCtrl[] skyBackgrounds;
    private int currentFadeIndex = 0;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("PlatformPoolManager�� �� �̻� �����մϴ�!");
            Destroy(this);
        }
    }
    public void OnItemCollected()
    {
        if(currentFadeIndex < skyBackgrounds.Length - 1) // ������ ����� �縮���� �ʾƾ� �ϹǷ� -1
        {
            skyBackgrounds[currentFadeIndex].StartFade();
            currentFadeIndex++;
        }
    }
}
