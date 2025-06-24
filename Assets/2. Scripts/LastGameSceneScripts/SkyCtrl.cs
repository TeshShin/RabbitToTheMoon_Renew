using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCtrl : MonoBehaviour
{
    private float speed = 0.25f;
    private SpriteRenderer sr;
    private bool shouldFade = false; // 제어 플래그
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(shouldFade)
        {
            DisapperBackground();
        }
    }
    private void DisapperBackground()
    {
        if (sr.color.a > 0)
        {
            Color color = sr.color;
            color.a -= Time.deltaTime * speed;
            sr.color = color;
        }
        else
        {
            shouldFade = false; // 다 사라지면 멈춤
        }
    }
    public void StartFade()
    {
        shouldFade = true;
    }
}

