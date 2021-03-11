using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    private int hp;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        hp = 10;
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

        if (Input.GetAxisRaw("Jump") != 0) {
            Shoot();
        }
    }

    public GameObject bullet;
    public Transform weapon0;
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    public AudioClip shootSFX;

    public void Shoot() {
        if (Time.time - _lastShootTimestamp < shootDelay)
            return;
        _lastShootTimestamp = Time.time;

        Instantiate(bullet, weapon0.position, Quaternion.identity);
        AudioManager.PlaySFX(shootSFX);
    }

    public void TakeDamage() {
        hp--;
        if (hp <= 0)
            Die();
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
