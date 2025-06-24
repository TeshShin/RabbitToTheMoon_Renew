using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LakeSceneMove : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("4. LakeScene");
		PlayerController.Inst.SetTransform(new Vector2(8.0f, -2.15f));
	}
}
