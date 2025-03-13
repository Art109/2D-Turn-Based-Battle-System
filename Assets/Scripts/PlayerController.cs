using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public static PlayerController Instance { get; private set; }

    PlayerCharacter playerUnit;
    public PlayerCharacter PlayerUnit { get { return playerUnit; } private set { playerUnit = value; } }

    float speed = 3;
    bool isWalking = false;
    Rigidbody2D rb;
    Animator animator;
    float direction;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerUnit = GetComponent<PlayerCharacter>();
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    #region "Player Control"
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
    #endregion


        
}
