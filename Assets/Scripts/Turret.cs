using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float firerate;
    private float cooldown;
    private GameObject player = null;

    public GameObject projectileClone;
    
    public Vector3 spawnPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firerate = 2;
        cooldown = 1;
        
        spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && cooldown <= 0)
        {
            player = other.gameObject;
            PlayerController pc = player.GetComponent<PlayerController>();
            Instantiate(projectileClone, spawnPos, quaternion.identity);
            ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
            cloneScript.playerController = pc;
            cooldown = firerate;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }

    }
}
