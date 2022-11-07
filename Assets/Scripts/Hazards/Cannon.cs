using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject butt;
    private float shootTime = 2;

    private void Update()
    {
        shootTime -= Time.deltaTime;
        if (shootTime < 0)
        {
            Fire();
            shootTime = 2;
        }
    }


    private void Fire()
    {
        Instantiate(bullet, butt.transform.position, butt.transform.rotation);
    }
}
