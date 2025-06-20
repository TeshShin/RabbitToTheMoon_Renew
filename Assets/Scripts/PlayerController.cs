using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// 전역
	public static Transform playerTransform;
	// 싱글톤
	private static PlayerController Instance;
	public static PlayerController Inst
	{
		get
		{
			return Instance;
		}
	}

	[Header("이동속도 세팅")]
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int jumpMax = 1; // 최대 점프 횟수
	private int jumpCount = 0; // 누적 점프 횟수
    [SerializeField] private float jumpForce = 500f;
	private Animator animator;
	private Rigidbody2D body2d;

	//Trigger Variable
	public bool isHuntered = false; // TODO : private으로 바꾸고 Inst를 통해 참조함으로써 캡슐화
	private bool isHi = false;
	private bool startHunt = false;

	private bool isGrounded = false;
	private bool isFalling = false;

	private void Awake()
	{
		//To change player's position after Scenemove
		playerTransform = gameObject.transform;

		if (Instance)
		{
			Debug.LogWarning("씬에 두 개 이상의 플레이어가 존재합니다!");
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		body2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void Update()
	{
		// 점프할 수 있다면
		if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)
		{
			Debug.Log("점프");
			jumpCount++;
			body2d.velocity = Vector2.zero;
			body2d.AddForce(new Vector2(0, jumpForce));
			isGrounded = false;
		}
		else if (Input.GetButtonUp("Jump") && body2d.velocity.y > 0)
		{
			// 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면(위로 상승 중)
			// 현재 속도를 절반으로 변경
			body2d.velocity = body2d.velocity * 0.5f;
		}
		if (body2d.velocity.y < 0f)
		{
			isFalling = true;
		}
		animator.SetBool("Grounded", isGrounded);
		animator.SetBool("Falling", isFalling);


		float inputX = Input.GetAxisRaw("Horizontal");
		float xSpeed = inputX * speed;
		//Appearance matching to moving direction
		if (inputX < 0)
		{
			transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
		}
		else if (inputX > 0)
		{
			transform.localScale = new Vector3(-1.3f, 1.3f, 1.0f);
		}
		// 대쉬
		if (Input.GetKey(KeyCode.LeftShift))
		{
			xSpeed = xSpeed * 2.5f;
		}


		body2d.velocity = new Vector2(xSpeed, body2d.velocity.y);


		animator.SetFloat("Speed", xSpeed);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		// 바닥에 닿았음을 감지하는 처리
		// 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있다면
		if (collision.gameObject.layer == 8 && collision.contacts[0].normal.y > 0.7f)
		{
			Debug.Log("점프회복");
			isGrounded = true;
			isFalling = false;
			jumpCount = 0;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		// 바닥에서 벗어났음을 감지하는 처리
		if (collision.gameObject.layer == 8)
			isGrounded = false;
	}
	public bool GetIsHi()
	{
		return isHi;
	}
	public void SetIsHi(bool setBool)
	{
		isHi = setBool;
	}
	public Transform GetTransform()
	{
		return gameObject.transform;
	}
	public void SetTransform(Vector3 vec)
	{
		transform.position = vec;
	}
    public bool GetIsHuntered()
    {
        return isHuntered;
    }
    public void SetIsHuntered(bool setBool)
    {
        isHuntered = setBool;
    }
    public bool GetStartHunt()
    {
		return startHunt;
    }
    public void SetStartHunt(bool setBool)
    {
        startHunt = setBool;
    }
}

