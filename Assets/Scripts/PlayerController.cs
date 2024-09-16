using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

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

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

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

    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //coins++
            score += 1;
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
        }
    }

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}