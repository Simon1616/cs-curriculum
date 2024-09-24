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
            gm.Health -= 10;

            if (gm.Health <= 0)
            {
                gm.Health = 100;

                gm.score -= 5;

                print("The Clerics of the Land tm thank you for using our services!");

                Debug.Log("Score:" + gm.score);

                if (gm.score < 0)
                {
                    print("Haha You're in debt! >:D");
                } 
            }
            
            Debug.Log("Health:" + gm.Health);

        }
    }
}
