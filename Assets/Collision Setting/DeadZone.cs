using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ToTheMoonPlayer.Inst.GameOver();
        }
        if(collision.CompareTag("Platform"))
        {
            Debug.Log("¹ßÆÇ°ú ´êÀ½");
            PlatformPoolManager.Inst.Relocation(collision.gameObject);
        }
    }
    
}
