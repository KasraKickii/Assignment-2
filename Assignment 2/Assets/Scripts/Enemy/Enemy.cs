using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    Rigidbody2D Rigidbody;
    BoxCollider2D Collide;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collide = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsFacingRight())
        {
            Rigidbody.velocity = new Vector2(movespeed, 0f);
        }
      else
        {
            Rigidbody.velocity = new Vector2(-movespeed, 0f);
        }
   
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
