using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        
        if(collision.collider.CompareTag("Target"))
        {
            Target hitTarget = collision.gameObject.GetComponent<Target>();
            hitTarget.TakeDamage(10f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
