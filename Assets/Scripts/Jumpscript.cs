using UnityEngine;

public class Jumpscript : MonoBehaviour
{
    private Collider2D collider2d;

    public float lengthuwu;
    public float launchforce;

    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        lengthuwu = 0.9f;
        launchforce = 400;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D leftray = Physics2D.Raycast(new Vector2(transform.position.x - collider2d.bounds.center.x, transform.position.y), Vector2.down, lengthuwu);
        RaycastHit2D rightray = Physics2D.Raycast(new Vector2(transform.position.x + collider2d.bounds.center.x, transform.position.y), Vector2.down, lengthuwu);

        if ((leftray.collider != null || rightray.collider != null) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((transform.up * launchforce));
        }
    }
}
