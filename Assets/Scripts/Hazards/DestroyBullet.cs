using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3);
    }
}
