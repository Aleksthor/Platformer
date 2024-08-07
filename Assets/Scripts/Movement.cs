using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AnimationController animController;
    Player player;
    Rigidbody2D rigidBody;
    public float movementSpeed = 5f;
    public float jumpingPower = 10f;
    public float jumpingGrace = 0.2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform doubleJumpParent;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool grounded;

    [Header("Effects")]
    [SerializeField] private GameObject doubleJumpEffect;

    [Header("Respawn")]
    [SerializeField] private Vector3 respawnPosition;
    private float respawnCacheTimer = 0f;
    private float respawnCacheTime = 5f;

    SpriteRenderer spriteRenderer;


    float horizontal = 0f;
    bool jump = false;
    float jumpGraceTimer = 0f;

    int doubleJumps = 1;
    bool releasedJump = false;
    bool pressedJump = false;
    bool flip = false;

    void Start()
    {
        player = GetComponent<Player>();
        animController = GetComponent<AnimationController>();   
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        grounded = IsGrounded();


        respawnCacheTimer += Time.deltaTime;
        if (respawnCacheTimer > respawnCacheTime)
        {
            respawnCacheTimer = 0f;
            if (grounded)
            {
                respawnPosition = transform.position;
            }
        }

        if (!grounded && jumpGraceTimer < jumpingGrace)
        {
            jumpGraceTimer += Time.deltaTime;
        }

        if (grounded)
        {
            jumpGraceTimer = 0f;
            doubleJumps = 1;
        }


        if (Input.GetAxisRaw("Jump") > 0f && jumpGraceTimer < jumpingGrace && !pressedJump)
        {
            pressedJump = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower);
            releasedJump = false;
        }
        if (Input.GetAxisRaw("Jump") > 0f && jumpGraceTimer > jumpingGrace && !pressedJump)
        {
            if (doubleJumps > 0 && player.HasStaff())
            {
                animController.TriggerDoubleJump();
                doubleJumps--;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower / 2);
                GameObject dJ = Instantiate(doubleJumpEffect, doubleJumpParent.transform.position, rigidBody.velocity.x > 0f ?
                    Quaternion.Euler(0,0,15f) : Quaternion.Euler(0, 0, -15f));

                dJ.transform.localScale = rigidBody.velocity.x > 0f ?
                        new Vector3(2, -1, 1) : new Vector3(-2, -1, 1);
                releasedJump = false;
                pressedJump = true;
            }
        }


        if (Input.GetAxisRaw("Jump") == 0f && rigidBody.velocity.y > 0f && !releasedJump)
        {
            releasedJump = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
        }

        if (Input.GetAxisRaw("Jump") == 0f && pressedJump)
        {
            pressedJump = false;
        }

    }
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2 (horizontal * movementSpeed, rigidBody.velocity.y);
        if (rigidBody.velocity.magnitude > 1f)
        {
            spriteRenderer.flipX = rigidBody.velocity.x > 0f;
        }
    }

    public bool IsWalking()
    {
        return Mathf.Abs(rigidBody.velocity.x) > 0.25f;
    }
    public bool Flip()
    {
        if (rigidBody.velocity.magnitude > 0f)
        {
            flip = rigidBody.velocity.x > 0f;
        }
        return flip;
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.33f, 0.1f),0f, groundLayer);
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        transform.position = respawnPosition;
    }
}
