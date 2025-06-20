using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	void Start()
	{
	}

	public void Button()
	{
		Invoke("StartGame", 1.5f);
	}

	public void Exit()
	{
		Application.Quit();
	}

	private void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
