using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float firerate;
    private float cooldown;
    public Vector3 targetPos;

    public GameObject projectilePrefab;
    
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && cooldown <= 0)
        {
            Debug.Log("shouldshoot");
            Instantiate(projectilePrefab, spawnPos, quaternion.identity);
            targetPos = other.gameObject.transform.position;
            cooldown = firerate;
        }
    }
}
