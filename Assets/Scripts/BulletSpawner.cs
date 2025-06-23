using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	[SerializeField] private AudioSource GunSound;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private GameObject firePos;
	[SerializeField] private float spawnRateMin = 1.3f;
	[SerializeField] private float spawnRateMax = 3.0f;

	private bool isSurprised = false;
	private Animator anim;

	private float spawnRate;
	private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
		if(TryGetComponent<Animator>(out anim))
		{

		}
		else
		{
			Debug.Log("Hunter - BulletSpawner.cs - Animator 등록 실패");
		}
			timeAfterSpawn = 0f;
		spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
		timeAfterSpawn += Time.deltaTime;
		if(PlayerController.Inst.GetIsHuntered() && !isSurprised)
        {
			anim.SetTrigger("Surprise");
			isSurprised = true;
        }

		if (PlayerController.Inst.GetStartHunt() && timeAfterSpawn >= spawnRate)
		{
			anim.SetBool("StartHunt", true);
            timeAfterSpawn = 0f;
			GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, transform.rotation);
			GunSound.Play();
			spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		}
	}
}