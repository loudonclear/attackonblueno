using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6;
    public float crouchControllerHeight;
    public Vector3 crouchControllerCenter;

    private float defaultControllerHeight;
    private Vector3 defaultControllerCenter;

    private float gravity;
    private float jumpVelocity;
    private Vector3 velocity;
    private float velocityXSmoothing;

    private CharacterController controller;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultControllerHeight = controller.height;
        defaultControllerCenter = controller.center;

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        if (((controller.collisionFlags & CollisionFlags.Above) != 0 && velocity.y > 0) || (controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = jumpVelocity;
        }
        

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.isGrounded) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Mathf.Abs(input.x) > 0.01)
        {
            if (controller.isGrounded)
            {
                animator.speed = 1;
            } else
            {
                animator.speed = 0;
            }

            if (input.x < 0)
            {
                spriteRenderer.flipX = true;
            } else
            {
                spriteRenderer.flipX = false;
            }
        } else
        {
            animator.speed = 0;
        }

        //if (Input.GetKey(KeyCode.LeftControl))
        //{
            //animator.SetTrigger("crouch");
            //controller.height = crouchControllerHeight;
            //controller.center = crouchControllerCenter;
        //} else
        //{
            //animator.SetTrigger("walk");
           // controller.height = defaultControllerHeight;
           // controller.center = defaultControllerCenter;
      //  }
    }

}