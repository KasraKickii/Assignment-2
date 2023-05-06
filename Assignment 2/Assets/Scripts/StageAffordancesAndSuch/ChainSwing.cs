using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSwing : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;

    [SerializeField] private float swingAmplitude;
    [SerializeField] private float swingFrequency;
    [SerializeField] private float leftAngle;
    [SerializeField] private float rightAngle;

    private float time = 0;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        movingClockwise = true;
        time = Mathf.PI * 0.75f;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        changeDiretion();
        Swing();
        time += Time.deltaTime;
    }

    public void changeDiretion()
    {
        if (transform.rotation.z>rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z<leftAngle)
        {
            movingClockwise = true;
        }
    }
    public void Swing()
    {
        rigid.angularVelocity = Mathf.Sin(time * swingFrequency) * swingAmplitude;
    }

}
