using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    private bool isLocked = true;
    public GameObject door;

    private void Update() {
        if (!isLocked)
        {
            door.GetComponent<Door>().open = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            isLocked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Box"))
        {
            isLocked = true;
        }
    }
}
