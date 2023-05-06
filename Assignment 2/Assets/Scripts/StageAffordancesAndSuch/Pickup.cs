using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Increases the player's score when collected.
/// </summary>
public class Pickup : MonoBehaviour
{
    private GameManager game;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player")) 
        { 
            game.score += 1; Destroy(gameObject); 
        };

    }
}