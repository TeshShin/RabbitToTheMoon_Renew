using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 8f;
	private Rigidbody2D bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
		bulletRigidbody = GetComponent<Rigidbody2D>();
		//bulletRigidbody.velocity = transform.forward * speed;

		Destroy(gameObject, 5f);
    }

	// Update is called once per frame
	private void Update()
	{
		transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
	}
	//When Hit bullet
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.transform.position = (new Vector3(1f, -1f, 0f));
			Destroy(this.gameObject);
		}
	}
}
