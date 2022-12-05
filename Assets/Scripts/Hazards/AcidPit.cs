using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class AcidPit : MonoBehaviour
{
    public float damageTimeout = 2f;
    private bool canTakeDamage = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Player"))
        {
            var hittable = other.GetComponent<IHittable>();
            hittable.GetHit(null, 1);
            StartCoroutine(DamageTimer());
        }
    }

    private IEnumerator DamageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}
