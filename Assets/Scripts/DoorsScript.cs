using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && player.smack == true && player.hasAxe == true)
        {
            Destroy(this.gameObject);
            Debug.Log("Door Opened");
        }
    }
}
