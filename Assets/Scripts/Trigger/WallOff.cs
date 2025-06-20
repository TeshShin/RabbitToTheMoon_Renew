using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOff : MonoBehaviour
{
	public bool ishuntered;

	void Update()
    {
		ishuntered = GameObject.FindWithTag("Player").GetComponent<PlayerController>().isHuntered;
		if (ishuntered)
		{
			gameObject.SetActive(false);
		}
    }
}
