using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = transform.parent.gameObject.GetComponent<PlayerController>();
    }

    // Animation Event
    public void EndLandingAnimation()
    {
        player.canJump = true;
    }

}
