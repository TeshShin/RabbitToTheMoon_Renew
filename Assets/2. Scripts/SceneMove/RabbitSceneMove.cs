using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RabbitSceneMove : MonoBehaviour
{
	[SerializeField] private AudioSource HunterBgm;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
            if (HunterBgm.isPlaying)
            {
                HunterBgm.Stop();
            }
            if (PlayerController.Inst.GetAudioSource().isPlaying == false)
            {
                PlayerController.Inst.GetAudioSource().Play();
            }
            SceneManager.LoadScene("3. RabbitScene");
            PlayerController.Inst.SetTransform(new Vector2(8.0f, -2.15f));
        }
	}
}
