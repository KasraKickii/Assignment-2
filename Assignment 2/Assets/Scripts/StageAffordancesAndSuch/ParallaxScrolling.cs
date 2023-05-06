using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that allows an object to create a parallax effect by scrolling.
/// </summary>
public class ParallaxScrolling : MonoBehaviour
{
    [Tooltip("Which transform is used as the parallax reference. Typically a camera.")]
    [SerializeField] private Transform followObject;

    [Tooltip("How much the parallax should scroll horizontally.")]
    [Range(-1.0f, 1.0f)]
    [SerializeField] private float scrollFactorX;

    [Tooltip("How much the parallax should scroll vertically.")]
    [Range(-1.0f, 1.0f)]
    [SerializeField] private float scrollFactorY;


    private void Start()
    {
        followObject = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        transform.position = Vector3.Scale(followObject.position, new Vector3(scrollFactorX, scrollFactorY));
    }
}
