using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private float swingspeed=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (transform.rotation.z > 0.35)
          {
              transform.Rotate(0, 0, Time.deltaTime * (swingspeed * -1));
          }
          if (transform.rotation.z <-0.35)
          {
              transform.Rotate(0, 0, Time.deltaTime * swingspeed);
          }
    }

}
