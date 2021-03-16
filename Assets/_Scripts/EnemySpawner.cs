using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField] private GameObject EnemyPrefab;

    private float timer;
    private float delay;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;
            for (int i = 0; i < 5; i++)
            {
                Spawn();
            }
            if (delay > 2)
                delay -= 0.1f;

        }
    }

    private void Spawn() 
    {
        int side = (int) Random.Range(0, 4);
        Vector3 p = new Vector3(0, 0, 0);

        if (side == 0) // right
        {
            p = new Vector3(-10, Random.Range(-6, 6), 1);
        }

        else if (side == 1) // top
        {
            p = new Vector3(Random.Range(-10, 10), 6, 1);
        }
        else if (side == 2) // left
        {
            p = new Vector3(10, Random.Range(-6, 6), 1);
        }
        else //bot
        {
            p = new Vector3(Random.Range(-10, 10), -6, 1);
        }

        GameObject enemy = Instantiate(EnemyPrefab, p, Quaternion.identity, transform);
        enemy.GetComponent<EnemyController>().setHUD(hud);
    }

    public void Reset()
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject); 
        }
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        timer = 0;
        delay = 4;
        for (int i = 0; i < 5; i++)
        {
            Spawn();
        }
    }
}
