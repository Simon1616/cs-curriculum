using System;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float firerate;
    private double cooldown;
    private GameObject player = null;

    public GameObject projectileClone;
    
    public Vector3 spawnPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firerate = 1;
        cooldown = 0.5;
        
        spawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (cooldown <= 0 && player != null)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            Instantiate(projectileClone, spawnPos, quaternion.identity);
            ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
            cloneScript.playerController = pc;
            cooldown = firerate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }

    }
}
