using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coins;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
