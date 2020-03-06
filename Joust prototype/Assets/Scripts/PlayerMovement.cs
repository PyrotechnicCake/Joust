using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public bool onGround = false;
    public GameObject player;
    
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround == true || Input.GetButtonDown("Jump"))
        {
            Vector2 CurrentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            CurrentVelocity.y = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
            // gameObject.GetComponent<Rigidbody2D>().velocity.y = (gameObject.GetComponent<Rigidbody2D>().velocity.x,0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
        }
    }
    
}
