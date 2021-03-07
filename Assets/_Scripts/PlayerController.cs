using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    private int vidas = 10;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Vel", 1.0f);
        }
        else
        {
            animator.SetFloat("Vel", 0.0f);
        }
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        vidas--;
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            TakeDamage();
        }
    }


}
