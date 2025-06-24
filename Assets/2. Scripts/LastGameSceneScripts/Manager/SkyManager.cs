using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    // 싱글톤
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
            Debug.Log("PlatformPoolManager가 둘 이상 존재합니다!");
            Destroy(this);
        }
    }
    public void OnItemCollected()
    {
        if(currentFadeIndex < skyBackgrounds.Length - 1) // 마지막 배경은 사리지지 않아야 하므로 -1
        {
            skyBackgrounds[currentFadeIndex].StartFade();
            currentFadeIndex++;
        }
    }
}
