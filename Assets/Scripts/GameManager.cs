using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int Health;

    public static GameManager gm;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;

    private Scene current;

    public bool hasAxe = false;

    public void Awake()
    {
        if (gm != null && gm != this)
        {
            //destroy self
            Destroy(gameObject);
        }
        else
        {
            //immortality
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Health = 100;
        Debug.Log("Health:" + Health);

        coinText.text = "Score: " + score;
        healthText.text = "Health: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void Die()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("Start");
            score = 0;
            Health = 100;
            coinText.text = "Score: " + score;
            healthText.text = "Health: " + Health;
        }
    }
}
