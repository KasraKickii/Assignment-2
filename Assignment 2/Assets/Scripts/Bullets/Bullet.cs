using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("How much damage this bullet should deal.")]
    [SerializeField] private int damage;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;

    private bool player;

    public void Initialize(Vector2 speed, bool player)
    {
        rigidBody.velocity = speed;
        this.player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player ? "Enemy" : "Player"))
        {
            collision.GetComponent<Health>().TryDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
