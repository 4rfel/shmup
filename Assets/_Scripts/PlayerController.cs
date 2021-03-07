using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }


}
