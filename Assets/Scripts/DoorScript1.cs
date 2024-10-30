using UnityEngine;

public class DoorsScript1 : MonoBehaviour
{
    private PlayerController player;

    private GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && player.smack == true && gm.hasAxe == true)
        {
            Destroy(this.gameObject);
            Debug.Log("Door Opened");
        }
    }
}