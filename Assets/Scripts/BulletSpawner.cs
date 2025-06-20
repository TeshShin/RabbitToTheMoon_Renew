using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	[SerializeField] private AudioSource GunSound;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float spawnRateMin = 1.3f;
	[SerializeField] private float spawnRateMax = 3.0f;

	private float spawnRate;
	private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
		timeAfterSpawn = 0f;
		spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
		timeAfterSpawn += Time.deltaTime;
		if(PlayerController.Inst.GetIsHuntered())
		{
			
		}

		if (PlayerController.Inst.GetStartHunt() && timeAfterSpawn >= spawnRate)
		{
			timeAfterSpawn = 0f;
			GameObject bullet = Instantiate(bulletPrefab, new Vector3(7f, -2.2f, 0f), transform.rotation);
			GunSound.Play();
			spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		}
	}
}