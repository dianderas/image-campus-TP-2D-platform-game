using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public bool open;
    public UnityEvent onOpen;
    private float startingY;
    private bool audioTrigered = false;


    private void Start()
    {
        startingY = transform.position.y;
    }

    private void Update()
    {
        if (open)
        {
            if (!audioTrigered)
            {
                audioTrigered = true;
                onOpen.Invoke();
            }

            openDoor();
        }
    }

    private void openDoor()
    {
        if (transform.position.y <= startingY + 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, 0);
            Debug.Log(transform.position);
        }
    }
}
