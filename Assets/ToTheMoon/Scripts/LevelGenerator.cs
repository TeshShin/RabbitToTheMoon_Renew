using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

	public float GameTime = 0;

	public int Maketimes = 999;
    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 1f;
    public float maxY = 3f;

	Vector3 spawnPosition = new Vector3();

	// Start is called before the first frame update
	void Start()
    {
		PlatformMake();
    }

	void Update()
	{
		GameTime += Time.deltaTime;
		if(GameTime >= 40f)
		{
			GameTime = 0f;
			PlatformMake();
		}
	}
	public void PlatformMake()
	{
			for (int i = 0; i < numberOfPlatforms; i++)
			{
				spawnPosition.y += Random.Range(minY, maxY);
				spawnPosition.x = Random.Range(-levelWidth, levelWidth);
				Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			}
	}
}

