using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSaw : MonoBehaviour
{
    [SerializeField] private float rollingSpeed=2f;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime * rollingSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TryDamage(2);
        }
    }
}
