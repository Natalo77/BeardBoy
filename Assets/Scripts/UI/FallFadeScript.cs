using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFadeScript : MonoBehaviour
{
    public LayerMask whatIsGround;          //Value in unity inspector -- Defines all tags that are to be used when checking if the player is grounded.
    public Rigidbody2D player;              //Value in unity inspector -- Passes the player character rigid body into this script.
    public Transform playerPosition;        //Value in unity inspector -- Passes the player character's current position into this script.
    public Transform groundCheck;           //Value in unity inspector -- An object placed at the center of the player's feet-circle collider.
    public float fallDamage;                //Value in unity inspector -- The amount of fade value to be applied as fall damage.
    public float velocityForFallDam;        //Value in unity inspector -- The vertical speed the player must go before qualifying for fall damage.

    private bool grounded;                  //Status variable for checking if the player is touching the ground or not.
    private bool vspeedQualifies;             //Boolean for checking whether the player has breached 10 vertical speed at any point.
    private float groundRadius = 0.55f;     //Used for the radius of an overlapCircle call in Update that checks if the player is grounded
    private float vspeed;                   //Used to store the value of the player characters's current vertical velocity.

    void Update()
    {
        /*
        Checks the players current grounded status and obtains their vertical velocity.
        If the player goes above 10 vertical velocity at any point a bool to represent this is set to true.
        When the player becomes grounded and has been above 10 vertical velocity during this 'fall'
            - Add a value to a variable in FadeScript which incorporates it into the screenfade calculations.
            - Sets the bool for the player having gone above 10 vertical velocity to false. 
        */

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        vspeed = Vector2.Dot(player.velocity, (groundCheck.position - playerPosition.position));

        if (vspeed > velocityForFallDam)
        {
            vspeedQualifies = true;
        }

        if (grounded && vspeedQualifies)
        {
            FadeScript.fallIncrement += fallDamage;
            vspeedQualifies = false;
        }
    }
}