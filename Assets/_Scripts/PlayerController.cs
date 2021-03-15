using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    private int hp;

    private Vector3 startP;

    private Animator animator;

    private Rigidbody2D rba;


    private void Start()
    {
        animator = GetComponent<Animator>();
        hp = 10;
        startP = transform.position;
        rba = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);


        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        Vector2 dir = new Vector2(diff.x, diff.y);
        dir = dir.normalized;

        dir = dir * yInput * 700;

        rba.AddForce(dir);
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
        AudioManager.PlaySFX(shootSFX, 0.2f);
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

    [SerializeField] private HUD hud;

    public void Restart()
    {
        hud.Restart();
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

    public int GetHP()
    {
        return hp;
    }
}
