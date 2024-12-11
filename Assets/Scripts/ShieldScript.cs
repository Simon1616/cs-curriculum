using System;
using UnityEngine;

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
        transform.position = player.gameObject.transform.position;
    }
}
