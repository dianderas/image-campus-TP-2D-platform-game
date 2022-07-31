using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public FloatVariable hp;

    public bool resetHp;
    public FloatReference startingHp;
    public UnityEvent damageEvent;
    public UnityEvent deathEvent;

    private void Start() {
        if (resetHp)
        {
            hp.SetValue(startingHp);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
        {
            hp.ApplyChange(-damage.damageAmount);
            damageEvent.Invoke();
        }

        if (hp.Value <= 0.0f)
        {
            deathEvent.Invoke();
        }
    }
}
