using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Camera cam;
    private Rect cam_rect;
    System.Random rnd = new System.Random();

    Vector2 movement;

    private float dirChangeRate = 0.5f;
    private float nextTimeToChangeDirection = 0f;

    private float shootRate = 10f;
    private float nextShoot = 0f;

    public Transform playerPos;

    public delegate void EventHandler();
    public static event EventHandler OnEnemyLeftScreen;

    private void Start()
    {
        cam = Camera.main;
        cam_rect = cam.pixelRect;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Generate our move vector
        if (Time.time >= nextTimeToChangeDirection)
        {
            // Change direction
            movement.x = (float)rnd.NextDouble() * 2 - 1;
            movement.y = (float)rnd.NextDouble() * 2 - 1;
            // Update next time to move
            nextTimeToChangeDirection = Time.time + 1f / dirChangeRate;
        }
    }

    void FixedUpdate()
    {
        // Movement
        Vector2 move = rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime;
        Vector3 position = cam.WorldToViewportPoint(move);
        if (position.x >= 0.0 && position.x <= 1.0 && position.y >= 0.0 && position.y <= 1.0)
        {
            rb.MovePosition(move);
        }
        else
        {
            nextTimeToChangeDirection = Time.time;
        }

        Vector2 shootDir = new Vector2(playerPos.position.x, playerPos.position.y) - rb.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnBecameInvisible()
    {
        if(gameObject.GetComponent<Target>().isDead)
        {
            return;
        }
        Destroy(gameObject);
        if (OnEnemyLeftScreen != null)
        {
            OnEnemyLeftScreen();
        }
    }
}
