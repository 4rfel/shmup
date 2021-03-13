using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour {

    private Vector3 direction;

    private float dist;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) 
            return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null)) {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    void Start() {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        dist = 0;
    }

    void Update() {
        Thrust(direction.x, direction.y);
        dist += direction.magnitude;
        if (dist >= 100)
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }

}