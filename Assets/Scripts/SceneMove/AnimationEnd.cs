using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Invoke("EndAnimation", 18.0f);
	}
	private void EndAnimation()
	{
		SceneManager.LoadScene("ToTheMoon");
	}
}
