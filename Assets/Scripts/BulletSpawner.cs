using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	public AudioSource GunSound;
	public GameObject bulletPrefab;
	public float spawnRateMin = 1.3f;
	public float spawnRateMax = 3.0f;

	public bool ishuntered = false;
	private float meethuntertime = 0f;
	private Transform target;
	private float spawnRate;
	private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
		timeAfterSpawn = 0f;
		spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
		meethuntertime = GameObject.FindWithTag("Trigger").GetComponent<MeetHunter>().meetHunterTime;
		ishuntered = GameObject.FindWithTag("Player").GetComponent<PlayerController>().isHuntered;

		timeAfterSpawn += Time.deltaTime;

		if (meethuntertime>=1.5f && ishuntered && timeAfterSpawn >= spawnRate)
		{
			timeAfterSpawn = 0f;
			GameObject bullet = Instantiate(bulletPrefab, new Vector3(7f, -2.2f, 0f), transform.rotation);
			GunSound.Play();
			//bullet.transform.LookAt(target);
			spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		}
	}
}