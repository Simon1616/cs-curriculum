using System;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CaveTurretscript : MonoBehaviour
{
    private float firerate;
    private double cooldown;

    public float xdir;
    public float ydir;

    public GameObject caveprojectileClone;
    
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
        
        if (cooldown <= 0)
        {
            Instantiate(caveprojectileClone, spawnPos, quaternion.identity);
            CaveprojectileScript cloneScript = caveprojectileClone.GetComponent<CaveprojectileScript>();
            cooldown = firerate;
            cloneScript.xdirection = xdir;
            cloneScript.ydirection = ydir;
        }
    }

}