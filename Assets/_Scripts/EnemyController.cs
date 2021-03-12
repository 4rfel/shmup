using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public void TakeDamage() {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate()
    {
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        Thrust(x, y);
       
    }

    public GameObject bullet;
    public Transform weapon0;

    public void Shoot() {
        Instantiate(bullet, weapon0.position, Quaternion.identity);
    }
}
