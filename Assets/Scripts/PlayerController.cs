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

    Rigidbody2D rb;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        gm.Current = SceneManager.();

        xspeed = 5;
        xdirection = 0;
        xvector = 0;

        yspeed = 5;
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
        xvector = xdirection * xspeed * Time.deltaTime;

        if (overworld)
        {
            ydirection = Input.GetAxis("Vertical");
            yvector = ydirection * yspeed * Time.deltaTime;
        }

        transform.Translate(xvector, yvector, 0);


    }

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}