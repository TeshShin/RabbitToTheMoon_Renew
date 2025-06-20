using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HunterSceneMove : MonoBehaviour

{
	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("HunterScene");
		PlayerController.playerTransform.position = new Vector2(-7.07f, -2.14f);
	}
}
