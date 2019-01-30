using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to control their character
public class CustomPlayerController : MonoBehaviour
{
    public static float maxSpeed;                           //Defines the maximum velocity for the rigidbody
    public static float moveForce;                          //Defines player acceleration speed
    public static float animationSpeed;                     //Defines the speed of the player's animation

    public static Animator animator;

    public float jumpForce;                                 //Value in unity inspector -- Defines strength of player jump
    public float rotationSpeed;                             //Value in unity inspector -- Defines how fast the player rotates
    public Transform groundCheck;                           //Value in unity inspector -- An object placed at the center of the player's feet-circle collider
    public LayerMask whatIsGround;                          //Value in unity inspector -- Defines all tags that are to be used when checking if the player is grounded

    private float groundRadius = 0.55f;                     //Used for the radius of an overlapCircle call in Update that checks if the player is grounded
    private float moving;                                   //The value of the user's horizontal-movement input

    private Rigidbody2D rigidBody;                          //Used for altering the player character.
    private SpriteRenderer spriteRenderer;                  //Used for rendering the player character.

    private Vector2 gravityDirection;                       //Placeholder variable used in calculation.
    private bool grounded = false;                          //Status variable for checking if the player is touching the ground or not.

    void Start()
    {
        maxSpeed = 10;
        moveForce = 15;
        animationSpeed = (float)1.5;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);       //isTouchingLayers is only called against the last physics system update which could cause frame delay errors with our future plans to add objects colliding with the player
        animator.SetBool("Grounded", grounded);

        float vspeed = Vector2.Dot(rigidBody.velocity, (groundCheck.position - transform.position));
        animator.SetFloat("vSpeed", vspeed);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector2(jumpForce * transform.up.x, jumpForce * transform.up.y));
        }

        animator.speed = animationSpeed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("HorizontalMovement", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("HorizontalMovement", false);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {

        /*
        Get a user input for horizontal movement.
        Perform any rotation.
        Obtain and add force in the direction of the player's feet (gravity).
        Add horizontal movement in the player's current horizontal direction only if grounded.
        Limit the player's velocity only if they are holding down the key and grounded. (This ensures falling velocity is not affected).
        */

        moving = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Rotate") != 0)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Input.GetAxis("Rotate"));
        }

        gravityDirection = new Vector2((groundCheck.position.x - transform.position.x), groundCheck.position.y - transform.position.y);
        rigidBody.AddForce(gravityDirection * 100);

        if (grounded)
        {
            rigidBody.AddForce(new Vector2(transform.right.x * moveForce * moving * 10, transform.right.y * moveForce * moving * 10));
        }
        else
        {
            rigidBody.AddForce(new Vector2(transform.right.x * moveForce * moving * 2, transform.right.y * moveForce * moving * 2));
        }

        if (Input.GetAxis("Horizontal") != 0 && grounded)
        {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maxSpeed);
        }
    }
}