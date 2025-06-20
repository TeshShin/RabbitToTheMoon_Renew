using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SampleSceneMove : MonoBehaviour
{
	public AudioSource HunterBgm;
	public AudioSource Peace;

	void Start()
	{
		Peace = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(HunterBgm.isPlaying)
		{
			HunterBgm.Stop();
		}
		if(Peace.isPlaying == false)
		{
			Peace.Play();
		}
		SceneManager.LoadScene("SampleScene");
		PlayerController.playerTransform.position = new Vector2(8.0f, -2.14f);
	}
}
