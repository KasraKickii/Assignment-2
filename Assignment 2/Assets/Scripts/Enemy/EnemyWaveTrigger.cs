using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveTrigger : MonoBehaviour
{
    [SerializeField] private EnemyWave wave;
    private float waveTimer = 0;
    private bool activated = false;

    private void FixedUpdate()
    {
        if (activated && waveTimer >= 0)
        {
            waveTimer += Time.deltaTime;

            if (waveTimer > 0.5f)
            {
                wave.Begin();
                waveTimer = -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            activated = true;
        }
    }
}
