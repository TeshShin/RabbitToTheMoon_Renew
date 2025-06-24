using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HunterSceneMove : MonoBehaviour

{
	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("2. HunterScene");
		PlayerController.Inst.SetTransform(new Vector3(-7.07f, -2.15f, 0f));
	}
}
