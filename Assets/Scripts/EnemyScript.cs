using System;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    enum states
    {
        patrolling,
        chasing,
        attacking,
        die
    }
    

    private states state;
    
    float speed = 2;
    private float duration = 5;
    
    private Vector3 target;
    
    private GameObject player = null;

    public PlayerController playerController;

    private Vector3 direction;

    private void Start()
    {
        state = states.patrolling;
        playerController = FindFirstObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (state == states.chasing)
        {
            Chase();
        }
        else if (state == states.attacking)
        {
            Attack();
        }
        else if (state == states.patrolling)
        {
            Patrol();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                state = states.chasing;
            }

            if (player != null)
            {
                state = states.attacking;
            }
            player = other.gameObject;
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (state == states.attacking)
            {
                state = states.chasing;
            }
            else if (state == states.chasing)
            {
                state = states.patrolling;
                player = null;
            }
        }
    }

    void Chase()
    {
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = ((target - transform.position).normalized) * speed;
        transform.position += (direction * Time.deltaTime);
    }

    void Attack()
    {
        Debug.Log("attacked");
    }

    void Patrol()
    {
        while (true)
        {
            
        }
    }
}
