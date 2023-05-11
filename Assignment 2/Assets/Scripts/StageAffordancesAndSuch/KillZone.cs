using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
   public InterstitialAd ad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TryDamage(10);
             ad.ShowAd();
        }
        if (collision.gameObject.CompareTag("IceTrap"))
        {
            Destroy(collision.gameObject);
        }
    }
}
