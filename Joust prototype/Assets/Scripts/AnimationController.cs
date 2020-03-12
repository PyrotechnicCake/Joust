using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public bool facingRight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("AnimState",2);
        }
        else if (GetComponent<PlayerMovement>().onGround == false || Input.GetButton("Jump"))
        {
            animator.SetInteger("AnimState", 3);
        }
        else if(GetComponent<PlayerMovement>().onGround == true && !Input.GetButton("Horizontal") && !Input.GetButton("Jump"))
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
