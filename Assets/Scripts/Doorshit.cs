using UnityEngine;

public class Doorshit : MonoBehaviour
{
    Switchscript switchScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Use FindObjectOfType if you're not using Unity 2023.1 or later
        switchScript = FindObjectOfType<Switchscript>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (switchScript.on == true)
        {
            Destroy(gameObject);
        }
    }
}
