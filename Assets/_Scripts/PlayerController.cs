using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    private int hp;

    private Vector3 startP;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        hp = 10;
        startP = transform.position;
        Debug.Log(startP);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

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

    [SerializeField] private GameObject gameover_menu;

    public void Die()
    {
        gameover_menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        hp = 10;
        transform.position = startP;
        gameover_menu.SetActive(false);
    }

    [SerializeField] private GameObject pause_menu;

    public void Pause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pause_menu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pause_menu.SetActive(true);
        }
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
