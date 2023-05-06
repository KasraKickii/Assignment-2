using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds and updates the player's score.
/// </summary>
public class GameManager : MonoBehaviour
{
    public int score;
    public bool canShoot = false;
    [SerializeField] private Text textmeshPro;
    
    void Update()
    {
        textmeshPro.text = "Score: " + score;
    }
    public void setboolshoot()
    {
        canShoot = true;
    }
}
