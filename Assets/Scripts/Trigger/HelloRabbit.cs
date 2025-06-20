using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloRabbit : MonoBehaviour
{
    private void Update()
    {
        transform.GetChild(0).gameObject.transform.position = new Vector3 (PlayerController.Inst.transform.position.x, PlayerController.Inst.transform.position.y + 2.5f, PlayerController.Inst.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (PlayerController.Inst.GetIsHi() == false)
		{
            transform.GetChild(0).gameObject.SetActive(true);
			Invoke("Disappear", 2f);
		}
	}
	private void Disappear()
	{
        PlayerController.Inst.SetIsHi(true);
        Destroy(gameObject);
	}
}
