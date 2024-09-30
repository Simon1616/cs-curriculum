using UnityEngine;

public class Turret : MonoBehaviour
{
    private int firerate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firerate = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
}
