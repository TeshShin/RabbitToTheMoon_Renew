using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGenerator : MonoBehaviour
{
	public GameObject platformPrefab;
	public int numberOfPlatforms = 40;
	public float levelWidth = 3f;
	public float minY = 9f;
	public float maxY = 30f;

	public float GameTime = 0;

	Vector3 spawnPosition = new Vector3();
	// Start is called before the first frame update
	void Start()
	{
		MakeNewPlatforms();
	}

	void Update()
	{
		GameTime += Time.deltaTime;
		if (GameTime >= 40f)
		{
			GameTime = 0f;
			MakeNewPlatforms();
		}
	}

	void MakeNewPlatforms()
	{
		for (int i = 0; i<numberOfPlatforms; i++)
			{
				spawnPosition.y += Random.Range(minY, maxY);
				spawnPosition.x = Random.Range(-levelWidth, levelWidth);
				Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			}
	}
    

}
