using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    float speed = 3;
    bool isWalking = false;
    Rigidbody2D rb;
    Animator animator;
    float direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }


    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX, moveY) * speed;


        if (moveX != 0 || moveY != 0)
        {
            isWalking = true;
            Flip();
        }
        else
            isWalking = false;

        animator.SetBool("isWalking", isWalking);


    }
    
    void Flip()
    {
        float newDirection = Input.GetAxisRaw("Horizontal");
        if (direction != newDirection && newDirection != 0)
        {
            direction = newDirection;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        

    }
}
