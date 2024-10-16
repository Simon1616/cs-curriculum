using System;
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
    int speed = 4;
    private Vector3 target;

    public PlayerController playerController;

    private void Start()
    {
        state = states.patrolling;
    }

    private void Update()
    {
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        if (state == states.chasing)
        {
            Chase();
        }
        else if (state == states.attacking)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        
    }

    void Chase()
    {
        
    }

    void Attack()
    {
        
    }
}
