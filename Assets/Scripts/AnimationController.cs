using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    Movement movement;
    Player player;
    public float groundedBuffer = 0.1f;
    private float groundTimer = 0f;

    private void Start()
    {
        player = GetComponent<Player>();
        movement = GetComponent<Movement>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walking", movement.IsWalking());
        animator.SetBool("Right", movement.Flip());
        if (!movement.IsGrounded())
        {
            groundTimer += Time.deltaTime;
            if (groundTimer > groundedBuffer)
            {
                animator.SetBool("Grounded", movement.IsGrounded());
            }
        }
        else
        {
            animator.SetBool("Grounded", movement.IsGrounded());
            groundTimer = 0f;
        }
        animator.SetBool("Staff", player.HasStaff());

    }

    public void TriggerDoubleJump()
    {
        animator.SetTrigger("DoubleJump");
    }
}
