using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CaveprojectileScript : MonoBehaviour
{
    private int speed = 4;
    private double lifespan = 30;
    private Vector2 velocity;
    public float xdirection;
    public float ydirection;
    
    private PlayerController player;

    private Rigidbody2D playerRB;

    private Vector2 add;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        playerRB = player.gameObject.GetComponent<Rigidbody2D>();
        // Initialize direction and velocity
        Vector2 direction = new Vector2(xdirection, ydirection).normalized;
        velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile based on its velocity (using Vector2 for 2D space)
        transform.position = (Vector2)transform.position + velocity * Time.deltaTime;

        lifespan -= Time.deltaTime;

        // Destroy projectile if lifespan expires
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile enters a trigger zone tagged "Shield"
        if (collider.CompareTag("Shield"))
        {
            // Find the closest point on the shield's collider to the projectile's position
            Vector2 closestPoint = collider.ClosestPoint((Vector2)transform.position);

            // Calculate the surface normal by subtracting the closest point from the projectile's position
            Vector2 surfaceNormal = (Vector2)transform.position - closestPoint;
            surfaceNormal.Normalize();  // Normalize the vector to get the unit normal

            // Reflect the velocity vector based on the surface normal
            velocity = Vector2.Reflect(velocity, surfaceNormal);

            // Optional: Apply some bounce factor to adjust the speed after bounce (e.g., dampen the movement)
            // velocity *= bounceFactor;

            Debug.Log("the starting velocity is "+velocity);
            Debug.Log(1);
            add = new Vector2(player.xvector, 0).normalized;
            velocity += add * player.xspeed;
            Debug.Log("the new velocity is " +velocity);
            Debug.Log("the player's velocity is " + player.xvector);
            if (velocity.magnitude < speed)
            {
                velocity = velocity.normalized;
                velocity *= speed;
            }
        }
        else if(!collider.CompareTag("Enemy") && !collider.CompareTag("Player") && !collider.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}