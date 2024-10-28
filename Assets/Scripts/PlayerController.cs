using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool overworld;

    public float playerX;
    public float playerY;

    float xspeed;
    float xdirection;
    float xvector;

    float yspeed;
    float ydirection;
    float yvector;

    private Vector3 movement;

    Rigidbody2D rb;

    public bool smack = false;
    public bool hasAxe = false;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        xspeed = 5f;
        xdirection = 0;
        xvector = 0;

        yspeed = 5f;
        ydirection = 0;
        yvector = 0;

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed;

        if (overworld)
        {
            ydirection = Input.GetAxis("Vertical");
            yvector = ydirection * yspeed;
        }

        movement = new Vector3(xdirection, ydirection, 0);
        if (movement.magnitude > 1);
        {
            movement = movement.normalized * xspeed;
        }

        transform.Translate(movement * Time.deltaTime);

        playerX = transform.position.x;
        playerY = transform.position.y;

        if (Input.GetMouseButton(0))
        {
            smack = true;
        }
        else
        {
            smack = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            hasAxe = true;
            Destroy(other.gameObject);
            Debug.Log("Axe Acquired");
        }
    }

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}