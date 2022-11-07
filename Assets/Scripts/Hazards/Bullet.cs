using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 3f;
    public int damage;
    [SerializeField]
    private Vector2 center = Vector2.zero;
    [SerializeField]
    [Range(0.1f, 2f)]
    private float radius = 1;
    [SerializeField]
    private Color gizmoColor = Color.red;
    public LayerMask layerMask;

    float mass = 10;
    float force = 1000;
    float accelaration;

    private void Update()
    {
        DetectCollision();
    }

    void LateUpdate()
    {
        accelaration = force / mass;
        speed += accelaration * Time.deltaTime;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void DetectCollision()
    {
        Collider2D collision = Physics2D.OverlapCircle((Vector2)transform.position + center, radius, layerMask);
        if (collision != null)
        {
            foreach (var hittable in collision.GetComponents<IHittable>())
            {
                hittable.GetHit(gameObject, damage);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position + (Vector3)center, radius);
    }
}
