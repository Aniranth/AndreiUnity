using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;

    public delegate void EventHandler();
    public static event EventHandler OnEnemyDie;

    public bool isDead = false;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
        if (OnEnemyDie != null)
        {
            OnEnemyDie();
        }
    }
}
