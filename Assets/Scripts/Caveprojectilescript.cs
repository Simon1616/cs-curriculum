using System;
using UnityEngine;

public class CaveprojectileScript : MonoBehaviour
{
    private int speed = 8;
    private Vector3 current;
    private double lifespan = 1.5;
    private Vector3 direction;
    private Vector3 velocity;
    public float xdirection;
    public float ydirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (velocity * Time.deltaTime);
        lifespan -= Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}   


