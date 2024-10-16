using UnityEngine;

public class SpotPlacer : MonoBehaviour
{
    private Vector3 placement;
    
    private int randomX;

    private int randomY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int minValue = -4;  // Minimum value (inclusive)
        int maxValue = 4; // Maximum value (exclusive)

        int randomX = Random.Range(minValue, maxValue);
        Debug.Log($"The random integer is: {randomX}");
        
        int randomY = Random.Range(minValue, maxValue);
        Debug.Log($"The random integer is: {randomY}");

        transform.Translate(randomX, randomY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
