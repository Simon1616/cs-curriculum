using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldScript : MonoBehaviour
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
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 99999999, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = player.transform.position;
        }
    }
}
