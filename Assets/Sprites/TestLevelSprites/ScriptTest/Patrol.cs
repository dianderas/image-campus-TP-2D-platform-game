using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public bool facingRight = false;
    public Rigidbody2D rigidbody2D;
    public Transform groundDetection;
    public Transform wallDetection;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float checkDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (facingRight)
        {
            rigidbody2D.velocity = new Vector2(Vector2.right.x * speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(Vector2.left.x * speed, rigidbody2D.velocity.y);
        }
        if (!GroundDetection())
        {
            Flip();
        }
        if (WallDetection())
        {
            Flip();
        }
    }
    private bool GroundDetection()
    {
        return Physics2D.Raycast(groundDetection.position, Vector2.down, checkDistance, groundLayer);
    }
    private bool WallDetection()
    {
        return Physics2D.Raycast(wallDetection.position, Vector2.right, checkDistance, wallLayer);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
}
