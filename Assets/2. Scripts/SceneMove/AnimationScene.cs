using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimationScene : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (PlayerController.Inst.GetAudioSource().isPlaying)
		{
            PlayerController.Inst.GetAudioSource().Stop();
		}
		Destroy(PlayerController.Inst.gameObject);
		SceneManager.LoadScene("5. AnimationScene");
	}	
}
