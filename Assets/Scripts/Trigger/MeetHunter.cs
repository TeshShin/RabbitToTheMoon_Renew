using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetHunter : MonoBehaviour
{
	[Header("필요한 연결시킬 오브젝트들")]
	[SerializeField] private GameObject wall;
	[SerializeField] private GameObject Gun;

	// 문구 세팅
	private GameObject runThink;
	private GameObject canvas;
	private GameObject runAway;
	private GameObject description;
	private GameObject what;
	private GameObject eventTrigger;



    public float meetHunterTime = 0f;

	[SerializeField] private AudioSource Hunter;
	// 뭘 재생하는 거징
	private AudioSource Peace;

    private void Awake()
    {
		// 문구 맞춰주기
		runThink = transform.GetChild(0).gameObject;
		canvas = transform.GetChild(1).gameObject;
		runAway = transform.GetChild(1).transform.GetChild(0).gameObject;
		description = transform.GetChild(1).transform.GetChild(1).gameObject;
		what = transform.GetChild(2).gameObject;
		eventTrigger = transform.GetChild(3).gameObject;

        runThink.SetActive(false);
		canvas.SetActive(false);
		runAway.SetActive(false);
		description.SetActive(false);
		what.SetActive(false);
		eventTrigger.SetActive(true);

        PlayerController.Inst.SetIsHuntered(false);
        PlayerController.Inst.SetStartHunt(false);
    }
    private void Start()
	{
		Peace = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
	}
	private void Update()
	{
        //  말풍선 위치를 플레이어 머리 위로 설정
        runThink.transform.position = new Vector3(PlayerController.Inst.transform.position.x - 1f, PlayerController.Inst.transform.position.y + 2.3f, PlayerController.Inst.transform.position.z);
        
		// 그냥 시간 체크하는 것인듯
		if(PlayerController.Inst.GetIsHuntered() == true)
		{
			meetHunterTime += Time.deltaTime;
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && PlayerController.Inst.GetIsHuntered() == false)
		{
			what.SetActive(true);
            eventTrigger.gameObject.SetActive(false);
            Invoke("RunAway",1.5f);
			Invoke("Disappear", 4f);
			Hunter.Play();
			Peace.Stop();
            PlayerController.Inst.SetIsHuntered(true);
        }
	}
	private void RunAway()
	{
        runThink.SetActive(true);
        canvas.SetActive(true);
        runAway.SetActive(true);
    }
    private void Disappear()
	{
		runThink.SetActive(false);
		what.SetActive(false);
        runAway.SetActive(false);
        description.SetActive(true);
		Destroy(wall);
        Gun.SetActive(true);
		PlayerController.Inst.SetStartHunt(true);
    }
}
