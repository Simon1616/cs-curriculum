using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool overworld;

    float xspeed;
    float xdirection;
    float xvector;

    float yspeed;
    float ydirection;
    float yvector;

    private Vector3 movement;

    Rigidbody2D rb;

    private void Start()
    {

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

        movement = new Vector3(xvector, yvector, 0);
        if (movement.magnitude > 1);
        {
            movement = movement.normalized;
        }

        transform.Translate(movement * Time.deltaTime);


    }

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}