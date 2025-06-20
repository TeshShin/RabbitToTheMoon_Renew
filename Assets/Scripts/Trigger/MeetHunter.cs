using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetHunter : MonoBehaviour
{
	public GameObject Gun;
	private bool ishuntered = false;
	public float meetHunterTime = 0f;

	public AudioSource Hunter;
	public AudioSource Peace;

	void Start()
	{
		Peace = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
	}
	void Update()
	{
		ishuntered = GameObject.FindWithTag("Player").GetComponent<PlayerController>().isHuntered;
		if(ishuntered == true)
		{
			meetHunterTime += Time.deltaTime;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(ishuntered== false)
		{
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(2).gameObject.SetActive(true);
			Invoke("Disappear", 2f);
			Gun.SetActive(true);
			transform.GetChild(1).gameObject.SetActive(true);
			Hunter.Play();
			Peace.Stop();

		}

		GameObject.FindWithTag("Player").GetComponent<PlayerController>().isHuntered = true;

	}
	private void Disappear()
	{
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(false);
	}
}
