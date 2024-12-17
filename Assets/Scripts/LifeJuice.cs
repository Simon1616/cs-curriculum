using System;
using UnityEngine;

public class LifeJuice : MonoBehaviour
{
    GameManager gm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.Health -= 20;

            Debug.Log("Health:" + gm.Health);
            gm.healthText.text = "Health: " + gm.Health;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile") && !Input.GetKey(KeyCode.LeftShift))
        {
            gm.Health -= 10;
            Destroy(other.gameObject);
            
            Debug.Log("Health:" + gm.Health);
            gm.healthText.text = "Health: " + gm.Health;
        }
    }
}
