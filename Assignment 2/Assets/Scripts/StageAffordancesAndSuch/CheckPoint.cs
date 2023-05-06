using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> Checkpoints;
    [SerializeField] private Vector3 VectorPoints;

    [SerializeField] private Health health;
    [SerializeField] private Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        health.OnDeath += OnDeath;
    }

    //Brings the player back to their previous checkpoint.
    private void OnDeath()
    {
        rigid.MovePosition(VectorPoints);
        health.Heal(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            VectorPoints = transform.position;
            Destroy(collision.gameObject);
        }
    }
}
