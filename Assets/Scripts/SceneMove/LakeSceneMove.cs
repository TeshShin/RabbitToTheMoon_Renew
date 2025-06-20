using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LakeSceneMove : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("LakeScene");
		PlayerController.playerTransform.position = new Vector2(8.0f, -2.14f);
	}
}
