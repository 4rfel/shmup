using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour {

    private float dist;
    private Vector3 direction;

    void Start()
    {
        dist = 0;
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (transform.position - posPlayer).normalized;
    }

    private void Update() {
        Thrust(direction.x, direction.y);
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
