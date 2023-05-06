using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast the player moves.")]
    [SerializeField] private float speed;
    [Tooltip("How much force the player jumps with.")]
    [SerializeField] private float jumpForce;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private BoxCollider2D playerCollider;

    private bool crouching = false;
    public bool canJump = false;
    public bool jumping;
    public Joystick joystick;
    [SerializeField] private float horizontalMovement = 0;
    private Vector2 hitboxIdle;
    private Vector2 hitboxCrouching;

    //Player Movement controller

    /// <summary>
    /// Takes the player's input for movement.
    /// </summary>
    /// 
    public void GetInputs()
    {
 

        //Horizontal Input
        if (IsJumping()) //In air
        {
            if (joystick.Horizontal >= .2f)
            {
                horizontalMovement = speed;

            }
            else if (joystick.Horizontal <= -.2f) { 
            
            horizontalMovement = -speed;
            }
            else
            {
                horizontalMovement = 0f;
            }
        }
        else //On ground
        {
            if (joystick.Horizontal >= .2f)
            {
                horizontalMovement = speed;

            }
            else if (joystick.Horizontal <= -.2f)
            {

                horizontalMovement = -speed;
            }
            else
            {
                horizontalMovement = 0f;
            }
        }

        //crouch
        /*        if (Input.GetKeyDown(KeyCode.C))
                {
                    sp.sprite = Crouch;
                    collider2D.size = CrouchSize;
                }
                if (Input.GetKeyUp(KeyCode.C))
                {
                    sp.sprite = Idel;
                    collider2D.size = IdelSize;
                }*/
    }
    
    /// <summary>
    /// Executes movement.
    /// </summary>
    private void Movement()
    {
        //Horizontal movement
        rigidBody.velocity = new Vector2(horizontalMovement, rigidBody.velocity.y);

        //Jumping
        if (jumping)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = false;
        }
    }

    /// <summary>
    /// Sets the player's CanJump variable to true. Used by groundcheck
    /// </summary>
    public void IsOnGround()
    {
        canJump = true;
        //if (canJump)
        //{
        //    Debug.Log("ok");
        //}
    }

    /// <summary>
    /// Returns true if the player is jumping.
    /// </summary>
    /// <returns></returns>
    public bool IsJumping()
    {
        return jumping || !canJump;
    }

    private void Start()
    {
        /*collider2D.size = IdelSize;
        sp.sprite = Idel;

        IdelSize = collider2D.size;*/
    }

    private void Update()
    {
        GetInputs();
    }

    public void FixedUpdate()
    {
        Movement();
    }
}
