using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour {

    private float dist;
    private Vector3 direction;
    [SerializeField] private ChangeStateDist csd;

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
        dist = 0;
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
    }

    void Update() {
        Thrust(direction.x, direction.y);
        if(Time.timeScale == 1)
        {
            dist += direction.magnitude;
        }
        if (dist >= 300)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }

}