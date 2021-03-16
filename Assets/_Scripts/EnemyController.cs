using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    private int hp;
    private HUD hud;

    void Start()
    {
        hp = 2;
    }

    public void setHUD(HUD h)
    {
        hud = h;
    }

    public void TakeDamage() {
        hp--;
        if(hp <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        hud.points += 10;
        hud.ResetTimer();
        Destroy(gameObject);
    }

    public GameObject bullet;
    public Transform weapon0;

    public void Shoot() {
        Instantiate(bullet, weapon0.position, Quaternion.identity);
    }
}
