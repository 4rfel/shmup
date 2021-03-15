using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaque : State {
    SteerableBehaviour steerable;
    IShooter shooter;

    [SerializeField] private ChangeStateDist csd;

    public override void Awake() {
        base.Awake();

        Transition ToPatrulha = new Transition();
        ToPatrulha.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            csd.dist);
        ToPatrulha.target = GetComponent<StatePatrulha>();

        transitions.Add(ToPatrulha);


        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if (shooter == null) {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Update() {

        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        Vector3 direction = (posPlayer - transform.position);

        Vector3 diff = Camera.main.ScreenToWorldPoint(direction) - transform.position;

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        if (Time.time - _lastShootTimestamp < shootDelay)
            return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}