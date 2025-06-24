using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class RabbitSceneRMove : MonoBehaviour

{
	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("3. RabbitScene");
		PlayerController.Inst.SetTransform(new Vector2(-7.07f, -2.15f));
	}
}