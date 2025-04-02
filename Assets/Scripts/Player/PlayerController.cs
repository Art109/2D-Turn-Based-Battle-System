using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Tilemaps;
using UnityEngine;

public enum PlayerState { Free, Battle}

public class PlayerController : MonoBehaviour
{
    
    public static PlayerController Instance { get; private set; }

    [Header("Player Battle Components")]
    [SerializeField]PlayerCharacter playerUnit;
    public PlayerCharacter PlayerUnit { get { return playerUnit; } private set { playerUnit = value; } }
    List<PlayerCharacter> playerParty;
    public List<PlayerCharacter> PlayerParty { get { return playerParty; } private set { PlayerParty = value; } }

    [Header("Movement Components")]
    [SerializeField]float speed = 3;
    bool isWalking = false;
    Rigidbody2D rb;
    float direction;

    
    PlayerState playerState = PlayerState.Free;
    public PlayerState PlayerState { get { return playerState; } set { playerState = value; } }

    Animator animator;


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
        playerParty = new List<PlayerCharacter>();
        playerParty.Add(playerUnit);
    }

    
    void Update()
    {
        if (playerState == PlayerState.Free)
            Movement();
        else if (playerState == PlayerState.Battle)
            PlayerBattleController.Instance.PlayerControl();

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

    public void StopMovement()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isWalking", false);
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
