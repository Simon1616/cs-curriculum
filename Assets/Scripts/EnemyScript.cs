using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyScript : MonoBehaviour
{
    private Vector3 etarget;
    private Vector3 current;
    private Vector3 direction;
    private GameManager gameManager;
    private PlayerController playerController;
    private float distance;
    public float state;
    private float changetime;
    private float iframes;


    void Start()
    {
        iframes = 750;
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindFirstObjectByType<GameManager>();
        changetime = 0;
        etarget = new Vector3(playerController.playerX, playerController.playerY, 0);
        state = 1;
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, etarget);
        if (distance < 4.5)
        {
            if (distance < 1.25)
                state = 3;
            else
                state = 2;
        }

        else
        {
            state = 1;
        }

        etarget = new Vector3(playerController.playerX, playerController.playerY, 0);

        if (state == 2) //CHASE
        {
            iframes -= 1;
            direction = ((etarget - transform.position).normalized);
            transform.Translate(direction * Time.deltaTime * 1.5f);
        }

        if (state == 3) //ATTACK
        {
            iframes -= 1;
            if (iframes < 1)
            {
                iframes = 900;
                gameManager.Health -= 10;
                
                Debug.Log("Health:" + gameManager.Health);
                gameManager.healthText.text = "Health: " + gameManager.Health;
            }
            direction = ((etarget - transform.position).normalized);
            transform.Translate(direction * Time.deltaTime * 0.5f);
        }

        current = transform.position;

        if (state == 1) //PATROL
        {
            changetime -= Time.deltaTime;
            if (changetime < 1)
            {
                changetime = Random.Range(1, 5);
                direction = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
            }
        }
        transform.Translate(direction * Time.deltaTime * 0.01f);
    }
}