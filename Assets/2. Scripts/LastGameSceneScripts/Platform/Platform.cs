using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType { Normal, Moving, SuperJump }

    [SerializeField] private PlatformType platformType = PlatformType.Normal;

    [Header("점프 세기")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float superJumpForce = 20f;

    [Header("이동 속도")]
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float moveRange = 8f;

    [Header("스프라이트")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite superJumpSprite;

    [Header("발판 사운드 설정")]
    private AudioSource jumpsound;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip superJumpClip;

    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;

    private void Awake()
	{
		jumpsound = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 초기 타입에 따라 스프라이트 설정
        ApplySpriteByType();
    }
    private void Update()
    {
        if (platformType == PlatformType.Moving)
        {
            MovePlatform();
        }
    }
    private void MovePlatform()
    {
        float movement = moveSpeed * Time.deltaTime;
        transform.Translate((movingRight ? Vector3.right : Vector3.left) * movement);

        if (transform.position.x >= moveRange)
        {
            movingRight = false;
        }
        else if (transform.position.x <= -moveRange)
        {
            movingRight = true;
        }
    }
    public void SetType(PlatformType type)
    {
        this.platformType = type;
        ApplySpriteByType();
    }
    // 타입에 따른 스프라이트
    private void ApplySpriteByType()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        switch (platformType)
        {
            case PlatformType.Normal:
            case PlatformType.Moving:
                spriteRenderer.sprite = normalSprite;
                jumpsound.clip = jumpClip;
                break;
            case PlatformType.SuperJump:
                spriteRenderer.sprite = superJumpSprite;
                jumpsound.clip = superJumpClip;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y <= 0f)
        {
			jumpsound.Play();
            ToTheMoonPlayer.Inst.SetGrounded(true);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 발판 타입에 따른 점프 세기
                float force = (platformType == PlatformType.SuperJump) ? superJumpForce : jumpForce;
                rb.velocity = new Vector2(rb.velocity.x, force);
            }
        }
    }
}