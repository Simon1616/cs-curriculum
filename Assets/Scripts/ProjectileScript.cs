using System;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    public PlayerController playerController = null;
    private int speed = 8;
    private Vector3 current;
    private double lifespan = 1.5;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = ((target - transform.position).normalized) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (direction * Time.deltaTime);
        lifespan -= Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }
}


