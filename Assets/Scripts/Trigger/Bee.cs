using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private void Update()
    {
        transform.GetChild(1).gameObject.transform.position = new Vector3(PlayerController.Inst.transform.position.x, PlayerController.Inst.transform.position.y + 2.5f, PlayerController.Inst.transform.position.z);
    }
    void OnTriggerEnter2D(Collider2D other)
	{
		if (PlayerController.Inst.GetIsBee() == false)
		{
			transform.GetChild(0).gameObject.SetActive(true);
			Invoke("Disappear", 3f);
			Invoke("Appearthink", 1.2f);
			Invoke("Disappearthink", 3f);
		}
	}
	private void Disappear()
	{
		Destroy(gameObject);
        PlayerController.Inst.SetIsBee(true);
	}
	private void Appearthink()
	{
		transform.GetChild(1).gameObject.SetActive(true);
	}
	private void Disappearthink()
	{
		transform.GetChild(1).gameObject.SetActive(false);
	}
}