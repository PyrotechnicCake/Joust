using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    public bool facingRight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = movement.direction;
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        if (movement.dragTouch.phase == TouchPhase.Moved)
        {
            animator.SetInteger("AnimState", 1);
        }
        else if (movement.dragTouch.phase == TouchPhase.Ended)
        {
            animator.SetInteger("AnimState",2);
        }
        else if (movement.onGround == false || Input.touchCount > 1)
        {
            animator.SetInteger("AnimState", 3);
        }
        else if(movement.onGround == true && Input.touchCount < 2 && gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            animator.SetInteger("AnimState", 0); 
        }
        

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
