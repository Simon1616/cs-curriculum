using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private int firerate;

    public GameObject projectileClone; 
    public Vector3 spawnPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firerate = 2;
        spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject clone = Instantiate(projectileClone, spawnPos, Quaternion.identity);
            ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
            
        }
    }
}
