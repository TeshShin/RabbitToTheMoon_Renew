using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        if (collision.gameObject.layer == 8)
            isGrounded = false;
    }
    public void SetGrounded(bool setbool)
    {
        isGrounded = setbool;
    }
}
