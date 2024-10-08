using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    public Vector3 direction;
    public int speed = 10;
    public float lifespan = 120;
    Turret Pos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pos = FindObjectOfType<Turret>();
        target = Pos.targetPos;
        direction = new Vector3(transform.position.x - target.x, transform.position.y - target.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
        direction = direction * speed;
        transform.Translate(direction * Time.deltaTime);
    }
}
