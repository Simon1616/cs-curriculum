using UnityEngine;

public class Money : MonoBehaviour
{
    GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.score += 1;
            Destroy(other.gameObject);
            Debug.Log("Score: " + gm.score);
            gm.coinText.text = "Score: " + gm.score;












        }
    }
}
