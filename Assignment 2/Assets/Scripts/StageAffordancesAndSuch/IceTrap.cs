using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigidbody2D.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
