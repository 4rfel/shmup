using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraController : MonoBehaviour, IDamageable {
    public void TakeDamage() {
        Die();
    }

    public void Die() {
        Destroy(gameObject);
    }
}
