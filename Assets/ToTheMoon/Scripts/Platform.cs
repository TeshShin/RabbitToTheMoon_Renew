using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public AudioSource jumpsound;
    public float jumpForce = 10f;

	private void Start()
	{
		jumpsound = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
			jumpsound.Play();
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y < -50)
        {
            Destroy(gameObject);
        }
    }
}
