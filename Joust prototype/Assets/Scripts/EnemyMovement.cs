using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float Speed = 5f;
    public bool onGround = false;
    public GameObject player;
    public Vector3 myTarget;
    public int myDir;
    public float jumpTime;

    private void Start()
    {
        //set targeet to x -11 to make it fly right
        //Vector3 myTarget = new Vector3(-11f, 0f, 0f);
        jumpTime = 0.9f;
    }

    void Update()
    {
        if (this.gameObject.transform.position.x > -11)
        {
            myDir = -1;
        }
        //jump every so often
        jumpTime -= Time.deltaTime;
        if (jumpTime < 0) {Jump();}
        //jump if you're getting too low
        if (this.gameObject.transform.position.y < -1) {Jump();}
        // wait to jump if too high
        if (this.gameObject.transform.position.y > 2) {jumpTime = 0.65f;}

        Vector3 movement = new Vector3(myDir, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }
    void Jump()
    {
        {
            Vector2 CurrentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            CurrentVelocity.y = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
            // gameObject.GetComponent<Rigidbody2D>().velocity.y = (gameObject.GetComponent<Rigidbody2D>().velocity.x,0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            jumpTime = 0.8f;
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
