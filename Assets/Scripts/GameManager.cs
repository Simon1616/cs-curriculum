using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int Health;

    public static GameManager gm;

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
        Debug.Log("Health" + Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
