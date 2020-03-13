using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public bool onGround = false;
    public GameObject player;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Touch touch;
    public Joystick joystick;
    float horizontalMove = 0f;


    void Update()
    {
        Jump();
        /*Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        /*if (touch.phase == TouchPhase.Moved)
        {
            /*touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            Vector3 touchMovement = new Vector3(direction.x,0) * Speed;

            Vector2 playerScreen = Camera.main.WorldToScreenPoint(transform.position);
            direction = ((Vector2)touchPosition - playerScreen);
            Vector2 touchMovement = new Vector2(direction.x, 0);
            transform.position = touchMovement * Time.deltaTime * Speed;
        }*/
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = Speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -Speed;
        }
        else
        {
            horizontalMove = 0;
        }
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
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 CurrentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            CurrentVelocity.y = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
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
