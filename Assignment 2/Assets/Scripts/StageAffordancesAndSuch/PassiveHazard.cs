using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveHazard : MonoBehaviour
{
    [Tooltip("How much damage this should deal on contact.")]
    [SerializeField] private int damage;
    [Tooltip("Is this hazard a trigger?")]
    [SerializeField] private bool isTrigger = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isTrigger && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Health>().TryDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTrigger && collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<Health>().TryDamage(damage);
        }
    }
}
