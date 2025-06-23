using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOff : MonoBehaviour
{

    private void Start()
    {
        if (PlayerController.Inst.GetIsHuntered())
        {
            Destroy(gameObject);
        }
    }
}
