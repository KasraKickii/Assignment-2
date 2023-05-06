using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BulletSource bulletSource;
    [SerializeField] private Health health;
    [SerializeField] private PlayerMovement movement;

    private bool facing = true;
    private float shootingCooldown = 0f;
    private float damageCooldown = 0f;

    private void Start()
    {
        health.OnDamaged += OnDamaged;
        bulletSource.OnShoot += OnShoot;
    }

    private void OnShoot()
    {
        shootingCooldown = 0.3f;
    }

    private void OnDamaged(bool value)
    {
        damageCooldown = 0.4f;
    }

    /// <summary>
    /// Changes animation parameters.
    /// </summary>
    /// <param name="deltaTime"></param>
    private void AnimationUpdate()
    {
        animator.SetBool("isRunning", Mathf.Abs(rigidbody.velocity.x) > 0.2f); //Player will be running when moving.
        spriteRenderer.flipX = !facing; //Sprite will face in the direction of the player.
        spriteRenderer.color = damageCooldown > 0 ? Color.clear : Color.white; //Sprite will flash clear when damaged
        animator.SetBool("isJumping", movement.IsJumping()); //Player jumping animation controlled by movement script.
        animator.SetBool("isShooting", shootingCooldown > 0); //Player will appear to be shooting when they have shot within the last 0.3 seconds
        bulletSource.SetFireOffset(facing ? new Vector2(1, 0.4f) : new Vector2(-1, 0.4f)); //Makes sure that bullets are always fired from the right side.
    }

    private void HandleFacingLogic(float velocity)
    {
        //Facing logic. The character will only turn in a direction when the player moves in that direction.
        if (velocity > 0.2f) 
        { 
            facing = true; 
        }
        else if (velocity < -0.2f) 
        { 
            facing = false; 
        }
    }

    /// <summary>
    /// Decrements cooldown timers.
    /// </summary>
    /// <param name="deltaTime"></param>
    private void HandleCooldowns(float deltaTime)
    {
        if (shootingCooldown > 0)
        {
            shootingCooldown -= deltaTime;
        }

        if (damageCooldown > 0)
        {
            damageCooldown -= deltaTime;
        }
    }

    private void Update()
    {
        AnimationUpdate();

        HandleFacingLogic(rigidbody.velocity.x);
    }

    private void FixedUpdate()
    {
        HandleCooldowns(Time.deltaTime);
    }
}
