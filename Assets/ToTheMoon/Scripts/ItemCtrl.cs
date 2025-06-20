using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCtrl : MonoBehaviour
{
    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y < -50)
        {
            Destroy(this.gameObject);
        }
    }
}