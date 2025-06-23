using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float speed = 8f;
    // Start is called before the first frame update
    private void Start()
    {
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
			other.transform.position = (new Vector3(5f, -2.15f, 0f));
			Destroy(this.gameObject);
		}
	}
}
