using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingOnPlat : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    private Rigidbody2D player;
    private Vector3 previousPos;
    private bool disconnected = true;
    private float disconnectTimer = 0;

    protected virtual void AdditionalUpdates()
    {

    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            player.MovePosition(player.transform.position + ((Vector3)player.velocity * Time.deltaTime) + (transform.position - previousPos));

        }
        previousPos = transform.position;
        AdditionalUpdates();


        if (disconnected) //Prevents the player from becoming unstuck due to sudden direction changes.
        {
            disconnectTimer += Time.deltaTime;
        }
        if (disconnectTimer > 0.2f)
        {
            player = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.rigidbody;
            disconnectTimer = 0;
            disconnected = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            disconnected = true;
        }
    }
}
