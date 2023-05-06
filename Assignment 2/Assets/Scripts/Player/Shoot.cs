using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public BulletSource bullet;

    public void shoots()
    {
        bullet.canShoot = true;
    }
}

