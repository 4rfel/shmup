using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour {

    private float dist;

    void Start()
    {
        dist = 0;
    }

    private void Update() {
        Thrust(1, 0);
        dist += 1;
        if (dist >= 80)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null)) {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
}
