using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Common
{
    public class DestroyUtil : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }

        public void DestroyObject(GameObject objectToDestroy)
        {
            Destroy(objectToDestroy);
        }
    }
}
