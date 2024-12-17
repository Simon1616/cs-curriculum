using UnityEngine;

public class CaveprojectileScript : MonoBehaviour
{
    private int speed = 8;
    private double lifespan = 30;
    private Vector2 velocity;
    public float xdirection;
    public float ydirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        }
        else if(!collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}