using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used solely for animating enemies.
/// </summary>
public class FinEnemy : MonoBehaviour
{
    [Tooltip("Whether or not this enemy has a falling animation.")]
    [SerializeField] private bool animateFall = false;

    [Header("References")]
    [SerializeField] private WalkingEnemy edgeDetection;
    [SerializeField] private Animator animator;

    private void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>(); //For some reason prefabs spawned by enemySpawners never had proper animator references.
        }
        edgeDetection.OnChangeDirection += ChangeDirection;

        if (animateFall)
        {
            edgeDetection.OnGroundedChange += OnGroundedChange;
        }
    }

    private void OnGroundedChange(bool grounded)
    {
        animator.SetBool("OnGround", grounded);
    }

    /// <summary>
    /// Causes enemies to flip their sprites when changing direction.
    /// </summary>
    /// <param name="right"></param>
    private void ChangeDirection(bool right)
    {
        animator.SetBool("Facing", right);
    }
}
