using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image image;

    private void FixedUpdate()
    {
        image.sprite = sprites[playerHealth.CurrentHealth - 1];
    }
}
