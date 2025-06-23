using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloRabbit : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        description.SetActive(false);
        PlayerController.Inst.SetIsHi(false);
    }
    [SerializeField] private GameObject description;
    private void Update()
    {
        // 말풍선 위치를 플레이어 머리 위로 설정
        transform.GetChild(0).gameObject.transform.position = new Vector3 (PlayerController.Inst.transform.position.x, PlayerController.Inst.transform.position.y + 2.5f, PlayerController.Inst.transform.position.z);
        transform.GetChild(2).gameObject.transform.position = new Vector3 (PlayerController.Inst.transform.position.x, PlayerController.Inst.transform.position.y + 2.5f, PlayerController.Inst.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (PlayerController.Inst.GetIsHi() == false)
		{
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("SayBBee", 1.5f);
            Invoke("Disappear", 1.5f);
            PlayerController.Inst.SetIsHi(true);
        }
	}
	private void Disappear()
	{
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void SayBBee()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        Invoke("Appearthink", 1.5f);
        Invoke("DisappearBBee", 1.5f);
    }
    private void DisappearBBee()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    private void Appearthink()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        description.SetActive(true);
        Invoke("Disappearthink", 2f);
    }
    private void Disappearthink()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }
    
}
