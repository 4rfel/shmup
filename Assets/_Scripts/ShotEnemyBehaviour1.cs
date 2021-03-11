using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour1 : SteerableBehaviour {
    void Update() {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        Vector3 direction = (posPlayer - transform.position).normalized;
        Thrust(direction.x, direction.y);
    }
}
