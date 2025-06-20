using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 [RequireComponent(typeof(Rigidbody2D))]
public class ToTheMoon_Player : MonoBehaviour
{

    public Button retryGame;    //
    public float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb;
    Transform spPoint;   //
    bool isDead = false;   //

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        retryGame.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;  //나중에 isDead를 통해 함수를 작용하기
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //Movement code here
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if(view.y<-50)
        {
            isDead = true;
            GameOver();
        }
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    void GameOver()
    {
        retryGame.gameObject.SetActive(true);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("ToTheMoon");
    }
}
