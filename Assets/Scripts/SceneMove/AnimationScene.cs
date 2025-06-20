using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimationScene : MonoBehaviour
{
	public AudioSource Peace;

	void Start()
	{
		Peace = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Peace.isPlaying)
		{
			Peace.Stop();
		}
		SceneManager.LoadScene("AnimationScene");
	}	
}
