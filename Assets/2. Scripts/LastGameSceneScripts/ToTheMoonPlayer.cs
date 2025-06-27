using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class ToTheMoonPlayer : MonoBehaviour
{
    // 싱글톤
    private static ToTheMoonPlayer inst;
    public static ToTheMoonPlayer Inst
    {
        get
        {
            return inst;
        }
    }
    [Header("게임 오버 UI")]
    [SerializeField] private GameObject gameOver; // 게임 오버 캔버스
    [Header("플레이어 이동속도 세팅")]
    [SerializeField] private float movementSpeed = 15f;
    [Header("점프 세기")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float superJumpForce = 20f;
    // 플레이어가 밟을 수 있는 현재 일반 발판과 다음 일반 발판의 최대 차이는 약 3.5362 이다.

    private float movement;
    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isGrounded = false;
    private bool isFalling = true;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("씬에 플레이어가 둘 이상 존재합니다!");
            Destroy(this);
        }
        rigidBody = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // 조작 난이도를 위해 Axis로
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (movement < 0)
        {
            transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
        }
        else if (movement > 0)
        {
            transform.localScale = new Vector3(-0.65f, 0.65f, 0.65f);
        }
        rigidBody.velocity = new Vector2(movement, rigidBody.velocity.y);

        if (rigidBody.velocity.y < 0f)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Falling", isFalling);

        animator.SetFloat("Speed", Input.GetAxis("Horizontal"));
    }
    // 맵밖으로 떨어지면 죽음
    public void GameOver()
    {
        gameOver.SetActive(true);
        GameManager.Inst.OnPlayerDead();
        Destroy(gameObject);
    }
    /// <summary>
    /// 점프 높이까지 올라간 후 
    /// 플레이어가 다시 아래로 내려가 발판과 부딪힐 때
    /// 다음 점프를 뛰도록 구현
    /// </summary>
    /// <param name="collision">Platform(발판)</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 && collision.contacts[0].normal.y > 0.5f)
        {
            if (collision.gameObject.tag == "Platform")
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
            else if (collision.gameObject.tag == "SuperPlatform")
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, superJumpForce);
            }
            isGrounded = true;
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }

    }
    public void SetGrounded(bool setbool)
    {
        isGrounded = setbool;
    }
}
