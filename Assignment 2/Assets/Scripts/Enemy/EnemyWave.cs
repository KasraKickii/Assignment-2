using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private EnemyWave nextWave;
    [SerializeField] private LockDoor exitTransition;

    private List<GameObject> enemies = new List<GameObject>();
    private float waveTimer = 0;
    private bool activated = false;

    private void FixedUpdate()
    {
        if (activated && enemies.Count == 0)
        {
            waveTimer += Time.deltaTime;

            if (waveTimer > 1.5f)
            {
                if (nextWave != null)
                {
                    nextWave.Begin();
                    activated = false;
                }
                else
                {
                    exitTransition.Open();
                }
            }
        }

        enemies.RemoveAll((GameObject enemy) => { return enemy == null; });
    }

    public void Begin()
    {
        activated = true;
        foreach (EnemySpawner spawner in GetComponentsInChildren<EnemySpawner>())
        {
            enemies.Add(spawner.Spawn());
        }
    }
}
